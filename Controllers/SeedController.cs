using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ⭐ GET: Seed players for a tournament (or master list if id = 0)
        [HttpGet("{tournamentId}")]
        public async Task<IActionResult> GetSeedPlayers(int tournamentId)
        {
            var players = await _context.SeedPlayers
                .Where(p => p.TournamentId == tournamentId)
                .OrderBy(p => p.Id)
                .ToListAsync();

            return Ok(players);
        }

        // ⭐ PUT: Update seed players (master or tournament)
        [HttpPut]
        public async Task<IActionResult> UpdateSeedPlayers([FromBody] List<SeedPlayer> updatedPlayers)
        {
            if (updatedPlayers == null || updatedPlayers.Count == 0)
                return BadRequest("No players provided.");

            var tournamentId = updatedPlayers.First().TournamentId;

            // ⭐ Load existing players for this tournament
            var existingPlayers = await _context.SeedPlayers
                .Where(p => p.TournamentId == tournamentId)
                .ToListAsync();

            // ⭐ Determine which players were deleted in the UI
            var idsSent = updatedPlayers
                .Where(p => p.Id > 0)
                .Select(p => p.Id)
                .ToHashSet();

            var toDelete = existingPlayers
                .Where(p => !idsSent.Contains(p.Id))
                .ToList();

            _context.SeedPlayers.RemoveRange(toDelete);

            // ⭐ Insert or update players
            foreach (var updated in updatedPlayers)
            {
                if (updated.Id == 0)
                {
                    // New player
                    var newPlayer = new SeedPlayer
                    {
                        Name = updated.Name,
                        Notes = updated.Notes,
                        AmountOwed = updated.AmountOwed,
                        AmountPaid = updated.AmountPaid,
                        Paid = updated.Paid,
                        TournamentId = updated.TournamentId
                    };

                    _context.SeedPlayers.Add(newPlayer);
                }
                else
                {
                    // Existing player
                    var existing = existingPlayers.FirstOrDefault(p => p.Id == updated.Id);

                    if (existing != null)
                    {
                        existing.Name = updated.Name;
                        existing.Notes = updated.Notes;
                        existing.AmountOwed = updated.AmountOwed;
                        existing.AmountPaid = updated.AmountPaid;
                        existing.Paid = updated.Paid;
                    }
                }
            }

            await _context.SaveChangesAsync();

            // ⭐ Return updated list
            var refreshed = await _context.SeedPlayers
                .Where(p => p.TournamentId == tournamentId)
                .OrderBy(p => p.Id)
                .ToListAsync();

            return Ok(refreshed);
        }

        // ⭐ POST: Add a new seed player (master or tournament)
        [HttpPost]
        public async Task<IActionResult> AddSeedPlayer([FromBody] SeedPlayer player)
        {
            if (player == null)
                return BadRequest("Player data missing.");

            _context.SeedPlayers.Add(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        // ⭐ DELETE: Remove a seed player
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeedPlayer(int id)
        {
            var player = await _context.SeedPlayers.FindAsync(id);

            if (player == null)
                return NotFound();

            _context.SeedPlayers.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}