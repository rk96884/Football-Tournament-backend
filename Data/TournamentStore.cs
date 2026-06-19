using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Data;

public static class TournamentStore
{
    public static List<Tournament> Tournaments { get; } = new()
    {
        new Tournament
        {
            Id = 1,
            Name = "Summer 2026 Tournaments",
            Date = DateTime.Now.AddDays(10),
            CostPerPlayer = 8,
            Notes = "",
            Location = new TournamentLocation
            {
                Address = "123 Sports Lane, Isleworth",
                MapUrl = "https://maps.google.com",
                Parking = "Limited street parking. Matchday restrictions on nearby roads."
            },
            Players = new List<Player>
            {
                new Player { Id = 1, Name = "Reuben", Attending = "unanswered", Paid = false, AmountPaid = 0, AmountOwed = 0, Notes = "" },
                new Player { Id = 2, Name = "Mason", Attending = "unanswered", Paid = false, AmountPaid = 0, AmountOwed = 0, Notes = "" },
                new Player { Id = 3, Name = "Adam", Attending = "unanswered", Paid = false, AmountPaid = 0, AmountOwed = 0, Notes = "" },
                new Player { Id = 4, Name = "Kyro", Attending = "unanswered", Paid = false, AmountPaid = 0, AmountOwed = 0, Notes = "" },
                new Player { Id = 5, Name = "Musa", Attending = "unanswered", Paid = false, AmountPaid = 0, AmountOwed = 0, Notes = "" },
                new Player { Id = 6, Name = "Aakayan", Attending = "unanswered", Paid = false, AmountPaid = 0, AmountOwed = 0, Notes = "" },
            }
        }
    };
    public static List<SeedPlayer> DefaultSeedPlayers { get; } = new()
{
    new SeedPlayer { Id = 1, Name = "Reuben", AmountOwed = 0, AmountPaid = 0, Paid = false, Notes = "" },
    new SeedPlayer { Id = 2, Name = "Mason", AmountOwed = 0, AmountPaid = 0, Paid = false, Notes = "" },
    new SeedPlayer { Id = 3, Name = "Adam", AmountOwed = 0, AmountPaid = 0, Paid = false, Notes = "" },
    new SeedPlayer { Id = 4, Name = "Kyro", AmountOwed = 0, AmountPaid = 0, Paid = false, Notes = "" },
    new SeedPlayer { Id = 5, Name = "Musa", AmountOwed = 0, AmountPaid = 0, Paid = false, Notes = "" },
    new SeedPlayer { Id = 6, Name = "Aakayan", AmountOwed = 0, AmountPaid = 0, Paid = false, Notes = "" },
};

}