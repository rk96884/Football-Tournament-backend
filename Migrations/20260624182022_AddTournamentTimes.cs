using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveAsideTournaments.Migrations
{
    /// <inheritdoc />
    public partial class AddTournamentTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KickOffTime",
                table: "Tournaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetTime",
                table: "Tournaments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KickOffTime",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "MeetTime",
                table: "Tournaments");
        }
    }
}
