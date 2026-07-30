using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;
using Microsoft.EntityFrameworkCore;

public class MasterSeedInitializer : IHostedService
{
    private readonly IServiceProvider _services;

    public MasterSeedInitializer(IServiceProvider services)
    {
        _services = services;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // ⭐ Remove duplicates
        var duplicates = await db.Tournaments
            .Where(t => t.Name == "Master Seed Team" && t.Id != 0)
            .ToListAsync(cancellationToken);

        if (duplicates.Any())
        {
            db.Tournaments.RemoveRange(duplicates);
            await db.SaveChangesAsync(cancellationToken);
        }

        // ⭐ Ensure master tournament exists
        if (!await db.Tournaments.AnyAsync(t => t.Id == 0, cancellationToken))
        {
            db.Tournaments.Add(new Tournament
            {
                Id = 0,
                Name = "Master Seed Team",
                Date = null,
                MeetTime = null,
                KickOffTime = null,
                CostPerPlayer = 0,
                Notes = "",
                Location = new TournamentLocation
                {
                    Address = "",
                    MapUrl = "",
                    Parking = ""
                }
            });

            await db.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}