namespace FiveAsideTournaments.Dtos;

public sealed record TournamentSummaryDto(
    int Id,
    string Name,
    DateTime? Date,
    string? Address,
    int PlayerCount,
    int ConfirmedCount,
    int AwaitingCount,
    int PaidCount,
    decimal OutstandingAmount);
