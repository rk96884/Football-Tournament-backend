using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FiveAsideTournaments.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Tournaments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tournaments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Location_Parking",
                table: "Tournaments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_MapUrl",
                table: "Tournaments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Address",
                table: "Tournaments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPerPlayer",
                table: "Tournaments",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tournaments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Paid",
                table: "SeedPlayers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SeedPlayers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SeedPlayers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "SeedPlayers",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOwed",
                table: "SeedPlayers",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SeedPlayers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Players",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "Paid",
                table: "Players",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Players",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Attending",
                table: "Players",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOwed",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "PaymentRecords",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PaymentRecords",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PaymentRecords",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PaymentRecords",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 9.17m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 9.17m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 9.17m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 9.17m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 9.17m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 9.17m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.00m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.00m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.00m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.00m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.00m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.00m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.18m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.18m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.18m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.18m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.18m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 10.18m, 0m, false });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 0m, 0m, false });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 0m, 0m, false });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 0m, 0m, false });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 0m, 0m, false });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 0m, 0m, false });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { 0m, 0m, false });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CostPerPlayer", "Date" },
                values: new object[] { 9.17m, new DateTime(2026, 6, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CostPerPlayer", "Date" },
                values: new object[] { 10.00m, new DateTime(2026, 6, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CostPerPlayer", "Date" },
                values: new object[] { 10.18m, new DateTime(2026, 6, 14, 12, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Tournaments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tournaments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location_Parking",
                table: "Tournaments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_MapUrl",
                table: "Tournaments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Address",
                table: "Tournaments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Tournaments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CostPerPlayer",
                table: "Tournaments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tournaments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Paid",
                table: "SeedPlayers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SeedPlayers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SeedPlayers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AmountPaid",
                table: "SeedPlayers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "AmountOwed",
                table: "SeedPlayers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SeedPlayers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Paid",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Players",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Attending",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AmountPaid",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "AmountOwed",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Timestamp",
                table: "PaymentRecords",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PaymentRecords",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "PaymentRecords",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PaymentRecords",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "9.17", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "9.17", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "9.17", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "9.17", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "9.17", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "9.17", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.00", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.00", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.00", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.00", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.00", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.00", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.18", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.18", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.18", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.18", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.18", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "10.18", "0", 0 });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "0", "0", 0 });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "0", "0", 0 });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "0", "0", 0 });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "0", "0", 0 });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "0", "0", 0 });

            migrationBuilder.UpdateData(
                table: "SeedPlayers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmountOwed", "AmountPaid", "Paid" },
                values: new object[] { "0", "0", 0 });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CostPerPlayer", "Date" },
                values: new object[] { "9.17", "2026-06-13 09:00:00" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CostPerPlayer", "Date" },
                values: new object[] { "10.00", "2026-06-28 09:00:00" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CostPerPlayer", "Date" },
                values: new object[] { "10.18", "2026-06-14 12:30:00" });
        }
    }
}
