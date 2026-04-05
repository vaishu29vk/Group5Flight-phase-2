using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5Flight.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeltaImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "ImageName",
                value: "delta.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Airlines",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "ImageName",
                value: "delta.png");
        }
    }
}
