using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiveAsideTournaments.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeedPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AmountOwed = table.Column<decimal>(type: "numeric", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    Paid = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedPlayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CostPerPlayer = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Location_Address = table.Column<string>(type: "text", nullable: true),
                    Location_MapUrl = table.Column<string>(type: "text", nullable: true),
                    Location_Parking = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Attending = table.Column<string>(type: "text", nullable: false),
                    Paid = table.Column<bool>(type: "boolean", nullable: false),
                    AmountOwed = table.Column<decimal>(type: "numeric", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    TournamentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "CostPerPlayer", "Date", "Name", "Notes", "Location_Address", "Location_MapUrl", "Location_Parking" },
                values: new object[,]
                {
                    { 1, 9.17m, new DateTime(2026, 6, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), "JOAP Rising Cup", "", "Barnhill High School, UB4 9LE", "", "" },
                    { 2, 10.00m, new DateTime(2026, 6, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), "FPF Tournament", "", "Rectory Park, UB5 5FA", "", "" },
                    { 3, 10.18m, new DateTime(2026, 6, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), "Oxford City Hoops Tournament", "Arrival 11:45 AM • Surface: 3G • Parking £5 (Card Only)", "Oxford City FC, Marsh Lane, Oxford, OX3 0NQ", "", "£5 (Card Only)" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AmountOwed", "AmountPaid", "Attending", "Name", "Notes", "Paid", "TournamentId" },
                values: new object[,]
                {
                    { 1, 9.17m, 0m, "unanswered", "Kyro", "", false, 1 },
                    { 2, 9.17m, 0m, "unanswered", "Reuben", "", false, 1 },
                    { 3, 9.17m, 0m, "unanswered", "Aakayan", "", false, 1 },
                    { 4, 9.17m, 0m, "unanswered", "Musa", "", false, 1 },
                    { 5, 9.17m, 0m, "unanswered", "Mason", "", false, 1 },
                    { 6, 9.17m, 0m, "unanswered", "Adam", "", false, 1 },
                    { 7, 10.00m, 0m, "unanswered", "Kyro", "", false, 2 },
                    { 8, 10.00m, 0m, "unanswered", "Reuben", "", false, 2 },
                    { 9, 10.00m, 0m, "unanswered", "Aakayan", "", false, 2 },
                    { 10, 10.00m, 0m, "unanswered", "Musa", "", false, 2 },
                    { 11, 10.00m, 0m, "unanswered", "Mason", "", false, 2 },
                    { 12, 10.00m, 0m, "unanswered", "Adam", "", false, 2 },
                    { 13, 10.18m, 0m, "unanswered", "Kyro", "", false, 3 },
                    { 14, 10.18m, 0m, "unanswered", "Reuben", "", false, 3 },
                    { 15, 10.18m, 0m, "unanswered", "Aakayan", "", false, 3 },
                    { 16, 10.18m, 0m, "unanswered", "Musa", "", false, 3 },
                    { 17, 10.18m, 0m, "unanswered", "Mason", "", false, 3 },
                    { 18, 10.18m, 0m, "unanswered", "Adam", "", false, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_PlayerId",
                table: "PaymentRecords",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TournamentId",
                table: "Players",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRecords");

            migrationBuilder.DropTable(
                name: "SeedPlayers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
