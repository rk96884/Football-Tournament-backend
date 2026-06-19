using Microsoft.EntityFrameworkCore;
using FiveAsideTournaments.Models;

namespace FiveAsideTournaments.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PaymentRecord> PaymentRecords { get; set; }
    public DbSet<SeedPlayer> SeedPlayers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SeedPlayer>().HasData(
    TournamentStore.DefaultSeedPlayers.ToArray()
);



        // -----------------------------------------
        // RELATIONSHIPS
        // -----------------------------------------

        modelBuilder.Entity<Player>()
            .HasOne(p => p.Tournament)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TournamentId);

        modelBuilder.Entity<Tournament>()
            .OwnsOne(t => t.Location);

        modelBuilder.Entity<PaymentRecord>()
            .HasKey(p => p.Id);

        // -----------------------------------------
        // TOURNAMENTS
        // -----------------------------------------
        modelBuilder.Entity<Tournament>().HasData(
            new Tournament
            {
                Id = 1,
                Name = "JOAP Rising Cup",
                Date = new DateTime(2026, 6, 13, 9, 0, 0),
                CostPerPlayer = 9.17m,
                Notes = ""
            },
            new Tournament
            {
                Id = 2,
                Name = "FPF Tournament",
                Date = new DateTime(2026, 6, 28, 9, 0, 0),
                CostPerPlayer = 10.00m,
                Notes = ""
            },
            new Tournament
            {
                Id = 3,
                Name = "Oxford City Hoops Tournament",
                Date = new DateTime(2026, 6, 14, 12, 30, 0),
                CostPerPlayer = 10.18m,
                Notes = "Arrival 11:45 AM • Surface: 3G • Parking £5 (Card Only)"
            }
        );

        // -----------------------------------------
        // LOCATION (OWNED TYPE SEEDING)
        // -----------------------------------------
        modelBuilder.Entity<Tournament>().OwnsOne(t => t.Location).HasData(
            new
            {
                TournamentId = 1,
                Address = "Barnhill High School, UB4 9LE",
                MapUrl = "",
                Parking = ""
            },
            new
            {
                TournamentId = 2,
                Address = "Rectory Park, UB5 5FA",
                MapUrl = "",
                Parking = ""
            },
            new
            {
                TournamentId = 3,
                Address = "Oxford City FC, Marsh Lane, Oxford, OX3 0NQ",
                MapUrl = "",
                Parking = "£5 (Card Only)"
            }
        );

        // -----------------------------------------
        // PLAYERS
        // -----------------------------------------
        int playerId = 1;

        void AddPlayer(string name, int tournamentId, decimal cost)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = playerId++,
                    Name = name,
                    TournamentId = tournamentId,
                    AmountPaid = 0,
                    AmountOwed = cost,
                    Attending = "unanswered",
                    Paid = false,
                    Notes = ""
                }
            );
        }

        // JOAP Rising Cup
        AddPlayer("Kyro", 1, 9.17m);
        AddPlayer("Reuben", 1, 9.17m);
        AddPlayer("Aakayan", 1, 9.17m);
        AddPlayer("Musa", 1, 9.17m);
        AddPlayer("Mason", 1, 9.17m);
        AddPlayer("Adam", 1, 9.17m);

        // FPF Tournament
        AddPlayer("Kyro", 2, 10.00m);
        AddPlayer("Reuben", 2, 10.00m);
        AddPlayer("Aakayan", 2, 10.00m);
        AddPlayer("Musa", 2, 10.00m);
        AddPlayer("Mason", 2, 10.00m);
        AddPlayer("Adam", 2, 10.00m);

        // Oxford City Hoops Tournament
        AddPlayer("Kyro", 3, 10.18m);
        AddPlayer("Reuben", 3, 10.18m);
        AddPlayer("Aakayan", 3, 10.18m);
        AddPlayer("Musa", 3, 10.18m);
        AddPlayer("Mason", 3, 10.18m);
        AddPlayer("Adam", 3, 10.18m);
    }
}