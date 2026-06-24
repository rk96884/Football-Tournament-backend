namespace FiveAsideTournaments.Models;

public class SeedPlayer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AmountOwed { get; set; }
    public decimal AmountPaid { get; set; }
    public bool Paid { get; set; }
    public string? Notes { get; set; }

    // ⭐ REQUIRED for linking seed players to tournaments
    public int TournamentId { get; set; }
    public Tournament? Tournament { get; set; }
}
