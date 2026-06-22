using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FiveAsideTournaments.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime? Date { get; set; }

        public decimal CostPerPlayer { get; set; } = 0;

        public string? Notes { get; set; }

        public TournamentLocation? Location { get; set; }

        public List<Player> Players { get; set; } = new();
    }

    [Owned]   // ⭐ THIS IS THE FIX
    public class TournamentLocation
    {
        public string? Address { get; set; }
        public string? MapUrl { get; set; }
        public string? Parking { get; set; }
    }
}
