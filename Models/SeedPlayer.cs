namespace FiveAsideTournaments.Models
{
    public class SeedPlayer
    {
        public int Id { get; set; }

        // ⭐ Always required for a seed player
        public string Name { get; set; } = string.Empty;

        // ⭐ Template financial fields (not used in real tournaments)
        public decimal AmountOwed { get; set; } = 0;
        public decimal AmountPaid { get; set; } = 0;
        public bool Paid { get; set; } = false;

        // ⭐ Optional notes
        public string? Notes { get; set; }

        // ⭐ 0 = Master Seed Team
        //    >0 = Seed team for a specific tournament (if ever needed)
        public int TournamentId { get; set; }

        // ⭐ Default attendance state for new tournaments
        public string Attending { get; set; } = "unanswered";

        // ⭐ Navigation property (optional but useful)
        public Tournament? Tournament { get; set; }
    }
}
