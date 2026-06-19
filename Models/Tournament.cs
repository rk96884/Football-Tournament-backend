using System.ComponentModel.DataAnnotations;

namespace FiveAsideTournaments.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        // Tournament name
        [Required]
        public string Name { get; set; } = string.Empty;

        // Optional date
        public DateTime? Date { get; set; }

        // Cost per player
        public decimal CostPerPlayer { get; set; } = 0;

        // Tournament-level notes (pitch type, organiser info, etc.)
        public string? Notes { get; set; }

        // Location object
        public TournamentLocation? Location { get; set; }

        // List of players
        public List<Player> Players { get; set; } = new();
    }

    public class TournamentLocation
    {
        public string? Address { get; set; }
        public string? MapUrl { get; set; }
        public string? Parking { get; set; }
    }
}