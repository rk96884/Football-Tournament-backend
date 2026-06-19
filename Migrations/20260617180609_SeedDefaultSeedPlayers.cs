using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiveAsideTournaments.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultSeedPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SeedPlayers",
                columns: new[] { "Id", "AmountOwed", "AmountPaid", "Name", "Notes", "Paid" },
                values: new object[,]
                {
                    { 1, 0m, 0m, "Reuben", "", false },
                    { 2, 0m, 0m, "Mason", "", false },
                    { 3, 0m, 0m, "Adam", "", false },
                    { 4, 0m, 0m, "Kyro", "", false },
                    { 5, 0m, 0m, "Musa", "", false },
                    { 6, 0m, 0m, "Aakayan", "", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
