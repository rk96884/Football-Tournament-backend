using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;
using FiveAsideTournaments.Dtos;
using FiveAsideTournaments.Services;
using Microsoft.Extensions.Caching.Memory;

namespace FiveAsideTournaments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public TournamentsController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // ⭐ GET: All tournaments (with players)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentSummaryDto>>> GetTournaments()
        {
            var tournaments = await _cache.GetOrCreateAsync(
                CacheKeys.TournamentOverview,
                async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(45);

                    return await _context.Tournaments
                        .AsNoTracking()
                        .Where(t => t.Name != "Master Seed Team")
                        .OrderBy(t => t.Date)
                        .Select(t => new TournamentSummaryDto(
                            t.Id,
                            t.Name,
                            t.Date,
                            t.Location != null ? t.Location.Address : null,
                            t.Players.Count,
                            t.Players.Count(p => p.Attending == "attending"),
                            t.Players.Count(p => p.Attending == "unanswered"),
                            t.Players.Count(p => p.Paid),
                            t.Players.Sum(p => p.AmountOwed - p.AmountPaid)))
                        .ToListAsync();
                });

            return Ok(tournaments);
        }

        // ⭐ GET: Single tournament (with players)
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments
                .AsNoTracking()
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournament == null)
                return NotFound();

            return Ok(tournament);
        }

        private string NormalizeTime(string? t)
        {
            if (string.IsNullOrWhiteSpace(t)) return "";
            // Accept "HH:mm" or "HH:mm:ss"
            return t.Length >= 5 ? t.Substring(0, 5) : t;
        }


        // Create a NEW tournament object (never trust the incoming one)
        [HttpPost]
        public async Task<ActionResult<Tournament>> CreateTournament([FromBody] Tournament tournament)
        {
            if (tournament == null)
                return BadRequest("Tournament data missing");

            // Create the tournament
            var newTournament = new Tournament
            {
                Name = tournament.Name,
                Date = tournament.Date,
                MeetTime = NormalizeTime(tournament.MeetTime),
                KickOffTime = NormalizeTime(tournament.KickOffTime),
                CostPerPlayer = tournament.CostPerPlayer,
                Notes = tournament.Notes,
                Location = tournament.Location
            };

            _context.Tournaments.Add(newTournament);
            await _context.SaveChangesAsync();

            // ⭐ Load master seed team (TournamentId = 0)
            var masterSeed = await _context.SeedPlayers
                .Where(p => p.TournamentId == 0)
                .ToListAsync();

            // ⭐ Copy into REAL tournament players table
            foreach (var p in masterSeed)
            {
                _context.Players.Add(new Player
                {
                    Name = p.Name,
                    Notes = p.Notes,
                    Attending = "unanswered",
                    Paid = false,
                    AmountPaid = 0,
                    AmountOwed = newTournament.CostPerPlayer,
                    TournamentId = newTournament.Id
                });
            }

            await _context.SaveChangesAsync();

            _cache.Remove(CacheKeys.TournamentOverview);

            return Ok(newTournament);
        }

        // ⭐ PUT: Update an existing tournament
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, [FromBody] Tournament updated)
        {
            var existing = await _context.Tournaments
                .Include(t => t.Location)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existing == null)
                return NotFound();

            if (updated.Location == null)
                return BadRequest("Location is required.");

            existing.Name = updated.Name;
            existing.Date = updated.Date;
            existing.CostPerPlayer = updated.CostPerPlayer;
            existing.MeetTime = NormalizeTime(updated.MeetTime);
            existing.KickOffTime = NormalizeTime(updated.KickOffTime);


            // ⭐ FIX: Update owned type properties individually
            existing.Location!.Address = updated.Location.Address!;
            existing.Location!.Parking = updated.Location.Parking!;

            // ⭐ Notes now saves correctly
            existing.Notes = updated.Notes;
            Console.WriteLine("=== RAW UPDATED OBJECT ===");
            Console.WriteLine("Name: " + updated.Name);
            Console.WriteLine("Date: " + updated.Date);
            Console.WriteLine("CostPerPlayer: " + updated.CostPerPlayer);
            Console.WriteLine("Notes: " + updated.Notes);
            Console.WriteLine("Location: " + (updated.Location == null ? "NULL" : "OK"));
            Console.WriteLine("Address: " + updated.Location?.Address);
            Console.WriteLine("Parking: " + updated.Location?.Parking);
            Console.WriteLine("==========================");
            await _context.SaveChangesAsync();

            _cache.Remove(CacheKeys.TournamentOverview);

            return NoContent();

        }


        // ⭐ DELETE: Remove a tournament (and its players)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _context.Tournaments
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournament == null)
                return NotFound();

            _context.Players.RemoveRange(tournament.Players);
            _context.Tournaments.Remove(tournament);

            await _context.SaveChangesAsync();

            _cache.Remove(CacheKeys.TournamentOverview);

            return NoContent();
        }
    }
}
