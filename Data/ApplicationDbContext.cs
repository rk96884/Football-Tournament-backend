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

        // RELATIONSHIPS
        modelBuilder.Entity<Player>()
            .HasOne(p => p.Tournament)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TournamentId);

        modelBuilder.Entity<Tournament>()
            .OwnsOne(t => t.Location);

        modelBuilder.Entity<PaymentRecord>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<SeedPlayer>()
            .HasOne(sp => sp.Tournament)
            .WithMany()
            .HasForeignKey(sp => sp.TournamentId);

    }
}