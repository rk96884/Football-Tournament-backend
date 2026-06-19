using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiveAsideTournaments.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        // Player name
        [Required]
        public string Name { get; set; } = string.Empty;

        // Attendance: "attending", "declined", "unanswered"
        public string Attending { get; set; } = "unanswered";

        // Payment status
        public bool Paid { get; set; } = false;

        // Money owed for the session
        public decimal AmountOwed { get; set; } = 0;

        // Money actually paid
        public decimal AmountPaid { get; set; } = 0;

        // Optional notes
        public string? Notes { get; set; }

        // Foreign key to Tournament
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }

        public Tournament? Tournament { get; set; }
    }
}