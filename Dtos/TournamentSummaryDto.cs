namespace FiveAsideTournaments.Dtos;

public sealed record TournamentSummaryDto(
    int Id,
    string Name,
    DateTime? Date,
    string? Address,
    int PlayerCount);
