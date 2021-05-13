using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class DropColumnsInWarehause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId",
                unique: true);
        }
    }
}
