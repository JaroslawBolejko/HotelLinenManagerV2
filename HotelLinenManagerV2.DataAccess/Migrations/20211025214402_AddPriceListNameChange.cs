using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddPriceListNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCoId",
                table: "PriceLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryCoId",
                table: "PriceLists",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCoId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "LaundryCoId",
                table: "PriceLists");
        }
    }
}
