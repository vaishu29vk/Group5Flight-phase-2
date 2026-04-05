using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group5Flight.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.AirlineId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightCode = table.Column<string>(type: "TEXT", nullable: false),
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    To = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CabinType = table.Column<string>(type: "TEXT", nullable: false),
                    AircraftType = table.Column<string>(type: "TEXT", nullable: false),
                    Emission = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AirlineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "AirlineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "AirlineId", "ImageName", "Name" },
                values: new object[,]
                {
                    { 1, "delta.png", "Delta Air Lines" },
                    { 2, "united.png", "United Airlines" },
                    { 3, "american.png", "American Airlines" },
                    { 4, "southwest.png", "Southwest Airlines" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AircraftType", "AirlineId", "ArrivalTime", "CabinType", "Date", "DepartureTime", "Emission", "FlightCode", "From", "Price", "To" },
                values: new object[,]
                {
                    { 1, "Boeing 737-900", 1, new DateTime(2000, 1, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), "Economy", new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), 170, "DL900", "Chicago", 210m, "Dallas" },
                    { 2, "Airbus A321", 2, new DateTime(2000, 1, 1, 14, 20, 0, 0, DateTimeKind.Unspecified), "Economy Plus", new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 230, "UA455", "Dallas", 295m, "Seattle" },
                    { 3, "Boeing 737 MAX 9", 3, new DateTime(2000, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), "Business", new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 6, 45, 0, 0, DateTimeKind.Unspecified), 140, "AA880", "Seattle", 520m, "San Francisco" },
                    { 4, "Boeing 737-700", 4, new DateTime(2000, 1, 1, 14, 45, 0, 0, DateTimeKind.Unspecified), "Basic Economy", new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 13, 15, 0, 0, DateTimeKind.Unspecified), 120, "WN720", "San Francisco", 130m, "Las Vegas" },
                    { 5, "Airbus A320", 1, new DateTime(2000, 1, 1, 13, 10, 0, 0, DateTimeKind.Unspecified), "Economy", new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 200, "DL330", "Las Vegas", 240m, "Chicago" },
                    { 6, "Boeing 737-800", 2, new DateTime(2000, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), "Economy Plus", new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 210, "UA999", "Chicago", 275m, "Miami" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                column: "AirlineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airlines");
        }
    }
}
