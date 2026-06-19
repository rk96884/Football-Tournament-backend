using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;      // ⭐ Needed for ApplicationDbContext
using FiveAsideTournaments.Models;    // ⭐ Needed for SeedPlayer

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

    [HttpGet("seed")]
    public async Task<IActionResult> GetSeedPlayers()
    {
        var players = await _context.SeedPlayers.ToListAsync();
        return Ok(players);
    }

    [HttpPut("seed")]
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
}