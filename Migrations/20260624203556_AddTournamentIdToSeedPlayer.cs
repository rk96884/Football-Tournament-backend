using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveAsideTournaments.Migrations
{
    /// <inheritdoc />
    public partial class AddTournamentIdToSeedPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "SeedPlayers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SeedPlayers_TournamentId",
                table: "SeedPlayers",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeedPlayers_Tournaments_TournamentId",
                table: "SeedPlayers",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeedPlayers_Tournaments_TournamentId",
                table: "SeedPlayers");

            migrationBuilder.DropIndex(
                name: "IX_SeedPlayers_TournamentId",
                table: "SeedPlayers");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "SeedPlayers");
        }
    }
}
