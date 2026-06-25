using FiveAsideTournaments.Data;
using FiveAsideTournaments.Models;   // ⭐ ADD THIS
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Bind to Render port
var port = Environment.GetEnvironmentVariable("PORT") ?? "5201";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Controllers + JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// ⭐ CORS — allow GitHub Pages
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy
            .WithOrigins("https://rk96884.github.io")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ⭐ Apply migrations BEFORE anything else
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    // ⭐ Ensure master tournament exists (fixes FK violation)
    if (!db.Tournaments.Any(t => t.Id == 0))
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

        db.SaveChanges();
    }
}

// ⭐ CORRECT MIDDLEWARE ORDER
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();