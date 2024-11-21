using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab6.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerCode = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerOtherDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameTitle = table.Column<string>(type: "TEXT", nullable: false),
                    GameRentalDailyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    GameNumberInStock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemTypes",
                columns: table => new
                {
                    InventoryItemTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryItemTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemTypes", x => x.InventoryItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieTitle = table.Column<string>(type: "TEXT", nullable: false),
                    MovieRentalDailyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    MovieNumberInStock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGameRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalDateOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RentalDateReturned = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RentalAmountDue = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGameRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGameRentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGameRentals_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InventoryItemTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryItemDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryItemId);
                    table.ForeignKey(
                        name: "FK_Inventories_InventoryItemTypes_InventoryItemTypeId",
                        column: x => x.InventoryItemTypeId,
                        principalTable: "InventoryItemTypes",
                        principalColumn: "InventoryItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMovieRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalDateOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RentalDateReturned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RentalAmountDue = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMovieRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMovieRentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMovieRentals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerCode", "CustomerName", "CustomerOtherDetails" },
                values: new object[,]
                {
                    { 1, "123 Main St", "C001", "John Doe", "Regular customer" },
                    { 2, "456 Oak St", "C002", "Jane Smith", "VIP customer" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameId", "GameNumberInStock", "GameRentalDailyRate", "GameTitle" },
                values: new object[,]
                {
                    { 1, 1, 7, 3.99m, "Halo" },
                    { 2, 2, 3, 2.99m, "FIFA" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItemTypes",
                columns: new[] { "InventoryItemTypeId", "CustomerId", "InventoryItemTypeDescription" },
                values: new object[,]
                {
                    { 1, 0, "DVD" },
                    { 2, 0, "Blu-ray" },
                    { 3, 0, "Game Disc" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "MovieId", "MovieNumberInStock", "MovieRentalDailyRate", "MovieTitle" },
                values: new object[,]
                {
                    { 1, 1, 10, 1.99m, "Inception" },
                    { 2, 2, 5, 2.49m, "The Matrix" }
                });

            migrationBuilder.InsertData(
                table: "CustomerGameRentals",
                columns: new[] { "Id", "CustomerId", "GameId", "RentalAmountDue", "RentalDateOut", "RentalDateReturned" },
                values: new object[,]
                {
                    { 1, 1, 1, 9.99m, new DateTime(2024, 11, 12, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9954), new DateTime(2024, 11, 15, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9956) },
                    { 2, 2, 2, 5.99m, new DateTime(2024, 11, 20, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9961), new DateTime(2024, 11, 21, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9962) }
                });

            migrationBuilder.InsertData(
                table: "CustomerMovieRentals",
                columns: new[] { "Id", "CustomerId", "MovieId", "RentalAmountDue", "RentalDateOut", "RentalDateReturned" },
                values: new object[,]
                {
                    { 1, 1, 1, 4.99m, new DateTime(2024, 11, 17, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9870), new DateTime(2024, 11, 20, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9926) },
                    { 2, 2, 2, 6.99m, new DateTime(2024, 11, 19, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9932), new DateTime(2024, 11, 21, 0, 1, 30, 445, DateTimeKind.Local).AddTicks(9933) }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryItemId", "InventoryItemDescription", "InventoryItemTypeId" },
                values: new object[,]
                {
                    { 1, "DVD - Inception", 1 },
                    { 2, "Blu-ray - The Matrix", 2 },
                    { 3, "Game Disc - Halo", 3 },
                    { 4, "Game Disc - FIFA", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGameRentals_CustomerId",
                table: "CustomerGameRentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGameRentals_GameId",
                table: "CustomerGameRentals",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovieRentals_CustomerId",
                table: "CustomerMovieRentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovieRentals_MovieId",
                table: "CustomerMovieRentals",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryItemTypeId",
                table: "Inventories",
                column: "InventoryItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGameRentals");

            migrationBuilder.DropTable(
                name: "CustomerMovieRentals");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "InventoryItemTypes");
        }
    }
}
