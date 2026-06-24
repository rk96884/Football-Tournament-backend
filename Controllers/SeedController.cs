using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SeedController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ⭐ GET: api/seed/4  → get seed players for tournament 4
    [HttpGet("{tournamentId}")]
    public async Task<IActionResult> GetSeedPlayers(int tournamentId)
    {
        var players = await _context.SeedPlayers
            .Where(p => p.TournamentId == tournamentId)
            .ToListAsync();

        return Ok(players);
    }

    // ⭐ POST: api/seed  → add a new seed player
    [HttpPost]
    public async Task<IActionResult> AddSeedPlayer([FromBody] SeedPlayer player)
    {
        _context.SeedPlayers.Add(player);
        await _context.SaveChangesAsync();
        return Ok(player);
    }

    // ⭐ PUT: api/seed  → update list of seed players
    [HttpPut]
    public async Task<IActionResult> UpdateSeedPlayers([FromBody] List<SeedPlayer> updatedPlayers)
    {
        foreach (var updated in updatedPlayers)
        {
            var existing = await _context.SeedPlayers.FindAsync(updated.Id);
            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.AmountOwed = updated.AmountOwed;
                existing.AmountPaid = updated.AmountPaid;
                existing.Paid = updated.Paid;
                existing.Notes = updated.Notes;
            }
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // ⭐ DELETE: api/seed/12  → delete seed player with id 12
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