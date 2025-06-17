using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolos2Poprawa.Migrations
{
    /// <inheritdoc />
    public partial class InnitModelsAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Nurseries",
                columns: table => new
                {
                    NurseryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurseries", x => x.NurseryId);
                });

            migrationBuilder.CreateTable(
                name: "TreeSpecieses",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatinName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GrowthTimeInYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSpecieses", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "SeedlingBatches",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseryId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SownDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedlingBatches", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_SeedlingBatches_Nurseries_NurseryId",
                        column: x => x.NurseryId,
                        principalTable: "Nurseries",
                        principalColumn: "NurseryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeedlingBatches_TreeSpecieses_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "TreeSpecieses",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => new { x.BatchId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_Responsibles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsibles_SeedlingBatches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "SeedlingBatches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kowalski" },
                    { 2, "Krzysztof", new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zalewski" },
                    { 3, "Grzegorz", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Floryda" }
                });

            migrationBuilder.InsertData(
                table: "Nurseries",
                columns: new[] { "NurseryId", "EstablishedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna" },
                    { 2, new DateTime(2022, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucja" },
                    { 3, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrycja" }
                });

            migrationBuilder.InsertData(
                table: "TreeSpecieses",
                columns: new[] { "SpeciesId", "GrowthTimeInYears", "LatinName" },
                values: new object[,]
                {
                    { 1, 2, "Bleblablu" },
                    { 2, 1, "Annograjka" },
                    { 3, 6, "Silwuple" }
                });

            migrationBuilder.InsertData(
                table: "SeedlingBatches",
                columns: new[] { "BatchId", "NurseryId", "Quantity", "ReadyDate", "SownDate", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 5, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 1, null, new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2, 7, null, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, 3, null, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 3, 9, null, new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Responsibles",
                columns: new[] { "BatchId", "EmployeeId", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Sprzatacz" },
                    { 1, 2, "Tancerz" },
                    { 1, 3, "Spiewak" },
                    { 2, 1, "Lekarz" },
                    { 2, 3, "Bulbulator" },
                    { 3, 2, "Mysisprzet" },
                    { 3, 3, "Ligma" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_EmployeeId",
                table: "Responsibles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedlingBatches_NurseryId",
                table: "SeedlingBatches",
                column: "NurseryId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedlingBatches_SpeciesId",
                table: "SeedlingBatches",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SeedlingBatches");

            migrationBuilder.DropTable(
                name: "Nurseries");

            migrationBuilder.DropTable(
                name: "TreeSpecieses");
        }
    }
}
