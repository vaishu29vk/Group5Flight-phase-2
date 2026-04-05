using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5Flight.Migrations
{
    /// <inheritdoc />
    public partial class RequiredFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 10, 15, 0, 0), new TimeSpan(0, 7, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 14, 20, 0, 0), new TimeSpan(0, 11, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 6, 45, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 14, 45, 0, 0), new TimeSpan(0, 13, 15, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 13, 10, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2000, 1, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2000, 1, 1, 14, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2000, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 6, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2000, 1, 1, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 13, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2000, 1, 1, 13, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2000, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
