using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class PriceDeletedFormHotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "HotelLinens");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "HotelLinens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "HotelLinens");

            migrationBuilder.AddColumn<string>(
                name: "PricePerKg",
                table: "HotelLinens",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }
    }
}
