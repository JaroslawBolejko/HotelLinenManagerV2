using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddEnumAndUpdePropInWarehause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelLinenAmount",
                table: "Warehauses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Warehauses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehauseNumber",
                table: "Warehauses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "WarehauseType",
                table: "Warehauses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Warehauses");

            migrationBuilder.DropColumn(
                name: "WarehauseNumber",
                table: "Warehauses");

            migrationBuilder.DropColumn(
                name: "WarehauseType",
                table: "Warehauses");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenAmount",
                table: "Warehauses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
