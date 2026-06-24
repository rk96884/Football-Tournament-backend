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
            if (updatedPlayers == null)
                return BadRequest("No players provided.");

            foreach (var updated in updatedPlayers)
            {
                var existing = await _context.SeedPlayers.FindAsync(updated.Id);

                if (existing != null)
                {
                    existing.Name = updated.Name;
                    existing.Notes = updated.Notes;
                    existing.AmountOwed = updated.AmountOwed;
                    existing.AmountPaid = updated.AmountPaid;
                    existing.Paid = updated.Paid;
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
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