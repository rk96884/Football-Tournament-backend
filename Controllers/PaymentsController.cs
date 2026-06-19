using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ⭐ Get payment history for a player
        [HttpGet("player/{playerId}")]
        public async Task<ActionResult<IEnumerable<PaymentRecord>>> GetHistory(int playerId)
        {
            var history = await _context.PaymentRecords
                .Where(p => p.PlayerId == playerId)
                .OrderByDescending(p => p.Timestamp)
                .ToListAsync();

            return Ok(history);
        }
    }
}