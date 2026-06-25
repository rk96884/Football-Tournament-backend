using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;   // ⭐ REQUIRED for DatabaseGenerated

namespace FiveAsideTournaments.Models
{
    public class Tournament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // ⭐ PREVENT auto‑generated IDs
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime? Date { get; set; }

        public string? MeetTime { get; set; }
        public string? KickOffTime { get; set; }

        public decimal CostPerPlayer { get; set; } = 0;

        public string? Notes { get; set; }

        public TournamentLocation? Location { get; set; } = new TournamentLocation();

        public List<Player> Players { get; set; } = new();
    }

    [Owned]
    public class TournamentLocation
    {
        public string? Address { get; set; }
        public string? MapUrl { get; set; }
        public string? Parking { get; set; }
    }
}