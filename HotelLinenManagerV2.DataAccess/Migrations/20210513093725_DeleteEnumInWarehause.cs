using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class DeleteEnumInWarehause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehauseType",
                table: "Warehauses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "WarehauseType",
                table: "Warehauses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
