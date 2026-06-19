namespace FiveAsideTournaments.Dtos;

public class UpdateAttendanceDto
{
    public int PlayerId { get; set; }
    public string Attending { get; set; } = ""; // yes/no/maybe
    public bool? Paid { get; set; } // optional
    public string Notes { get; set; } = "";
}
