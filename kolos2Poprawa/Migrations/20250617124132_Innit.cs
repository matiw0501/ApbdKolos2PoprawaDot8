using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolos2Poprawa.Migrations
{
    /// <inheritdoc />
    public partial class Innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 1,
                column: "ReadyDate",
                value: new DateTime(2029, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 2,
                column: "ReadyDate",
                value: new DateTime(2028, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 3,
                column: "ReadyDate",
                value: new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 4,
                column: "ReadyDate",
                value: new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 5,
                column: "ReadyDate",
                value: new DateTime(2030, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 1,
                column: "ReadyDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 2,
                column: "ReadyDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 3,
                column: "ReadyDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 4,
                column: "ReadyDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 5,
                column: "ReadyDate",
                value: null);
        }
    }
}
