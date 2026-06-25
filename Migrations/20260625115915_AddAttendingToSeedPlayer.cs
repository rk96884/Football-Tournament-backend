using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveAsideTournaments.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendingToSeedPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attending",
                table: "SeedPlayers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attending",
                table: "SeedPlayers");
        }
    }
}
