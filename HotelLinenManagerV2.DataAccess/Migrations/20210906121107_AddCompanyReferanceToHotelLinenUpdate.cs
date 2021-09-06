using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddCompanyReferanceToHotelLinenUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComapnyId",
                table: "HotelLinens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComapnyId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
