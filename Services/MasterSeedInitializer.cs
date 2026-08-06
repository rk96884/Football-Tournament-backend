using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;
using Microsoft.EntityFrameworkCore;

public class MasterSeedInitializer : BackgroundService
{
    private readonly IServiceProvider _services;

    public MasterSeedInitializer(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        // Allow the web host to begin accepting requests before touching the database.
        await Task.Yield();

        using var scope = _services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // ⭐ Retry logic to avoid Render cold-start failures
        var retries = 5;
        while (retries > 0)
        {
            try
            {
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

                // ⭐ Success — exit retry loop
                return;
            }
            catch (Exception ex)
            {
                retries--;
                Console.WriteLine($"MasterSeedInitializer retry failed ({ex.Message}). Retries left: {retries}");
                await Task.Delay(1000, cancellationToken); // wait 1 second
            }
        }

        Console.WriteLine("MasterSeedInitializer failed after retries — continuing without seeding.");
    }

}
