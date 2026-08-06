using FiveAsideTournaments.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5201";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(
            "https://rk96884.github.io",   // production
            "http://localhost:5173"        // development
            )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var connectionString =
    builder.Configuration["CONNECTION_STRING"] ??
    builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("A PostgreSQL connection string is required.");

var connectionBuilder = new NpgsqlConnectionStringBuilder(connectionString)
{
    Pooling = true,
    MaxPoolSize = 10,
    Timeout = 5,
    CommandTimeout = 15
};

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionBuilder.ConnectionString));

builder.Services.AddMemoryCache();
builder.Services.AddHostedService<MasterSeedInitializer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// OPTIONAL: apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // db.Database.Migrate();
}

// ⭐ REQUIRED for Render HTTPS → container HTTP
app.UseHttpsRedirection();

app.UseRouting();

// ⭐ Correct policy name
app.UseCors("_myAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
