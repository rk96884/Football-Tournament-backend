using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ⭐ GET: All players for a tournament
        [HttpGet("tournament/{tournamentId}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersForTournament(int tournamentId)
        {
            var players = await _context.Players
                .Where(p => p.TournamentId == tournamentId)
                .ToListAsync();

            return Ok(players);
        }

        // ⭐ GET: Single player
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            return Ok(player);
        }

        // ⭐ POST: Add a new player to ONE tournament
        [HttpPost("{tournamentId}")]
        public async Task<ActionResult<Player>> AddPlayer(int tournamentId, [FromBody] Player player)
        {
            if (player == null)
                return BadRequest("Player data missing");

            // Ensure tournament exists
            var tournament = await _context.Tournaments
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == tournamentId);

            if (tournament == null)
                return NotFound("Tournament not found");

            var newPlayer = new Player
            {
                Name = player.Name,
                Notes = player.Notes,
                Attending = "unanswered",
                Paid = false,
                AmountPaid = 0,
                AmountOwed = tournament.CostPerPlayer,
                TournamentId = tournamentId
            };

            tournament.Players.Add(newPlayer);
            await _context.SaveChangesAsync();

            return Ok(newPlayer);
        }

        // ⭐ PUT: Update an existing player
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] Player updated)
        {
            var existing = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);

            if (existing == null)
                return NotFound();

            // Update fields
            existing.Name = updated.Name;
            existing.Attending = updated.Attending;
            existing.Paid = updated.Paid;
            existing.AmountPaid = updated.AmountPaid;
            existing.AmountOwed = updated.AmountOwed;
            existing.Notes = updated.Notes;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("bulkupdate/{tournamentId}")]
        public async Task<IActionResult> BulkUpdatePlayers(int tournamentId, [FromBody] List<Player> players)
        {
            if (players == null)
                return BadRequest("No players provided.");

            // Load existing players for this tournament
            var existing = await _context.Players
                .Where(p => p.TournamentId == tournamentId)
                .ToListAsync();

            // Update existing players
            foreach (var p in players)
            {
                var match = existing.FirstOrDefault(x => x.Id == p.Id);

                if (match != null)
                {
                    match.Name = p.Name;
                    match.Notes = p.Notes;
                    match.Attending = p.Attending;
                    match.Paid = p.Paid;
                    match.AmountPaid = p.AmountPaid;
                    match.AmountOwed = p.AmountOwed;
                }
                else
                {
                    // New player
                    p.TournamentId = tournamentId;
                    _context.Players.Add(p);
                }
            }

            // Remove players that were deleted in the UI
            foreach (var old in existing)
            {
                if (!players.Any(p => p.Id == old.Id))
                    _context.Players.Remove(old);
            }

            await _context.SaveChangesAsync();

            // Return updated list
            var updated = await _context.Players
                .Where(p => p.TournamentId == tournamentId)
                .ToListAsync();

            return Ok(updated);
        }

        // ⭐ DELETE: Remove a player
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}