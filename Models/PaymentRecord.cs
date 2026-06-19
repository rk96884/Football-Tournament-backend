using System;

namespace FiveAsideTournaments.Models;

public class PaymentRecord
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Player? Player { get; set; }   // ✅ Nullable navigation property
}
