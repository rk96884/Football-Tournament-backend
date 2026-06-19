using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ⭐ GET: All tournaments (with players)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
            var tournaments = await _context.Tournaments
                .Include(t => t.Players)
                .ToListAsync();

            return Ok(tournaments);
        }

        // ⭐ GET: Single tournament (with players)
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournament == null)
                return NotFound();

            return Ok(tournament);
        }

        // Create a NEW tournament object (never trust the incoming one)
        [HttpPost]
        public async Task<ActionResult<Tournament>> CreateTournament([FromBody] Tournament tournament)
        {
            if (tournament == null)
                return BadRequest("Tournament data missing");

            var seedPlayers = await _context.SeedPlayers.ToListAsync();

            var newTournament = new Tournament
            {
                Name = tournament.Name,
                Date = tournament.Date,
                CostPerPlayer = tournament.CostPerPlayer,
                Notes = tournament.Notes,
                Location = tournament.Location,
                Players = seedPlayers.Select(sp => new Player
                {
                    Name = sp.Name,
                    Notes = sp.Notes,
                    Attending = "unanswered",
                    Paid = false,
                    AmountPaid = 0,
                    AmountOwed = tournament.CostPerPlayer
                }).ToList()
            };

            _context.Tournaments.Add(newTournament);
            await _context.SaveChangesAsync();

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

            existing.Name = updated.Name;
            existing.Date = updated.Date;
            existing.CostPerPlayer = updated.CostPerPlayer;

            // ⭐ FIX: Update owned type properties individually
            existing.Location.Address = updated.Location.Address;
            existing.Location.Parking = updated.Location.Parking;

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

            return NoContent();
        }
    }
}