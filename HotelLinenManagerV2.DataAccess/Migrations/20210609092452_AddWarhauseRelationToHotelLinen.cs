using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddWarhauseRelationToHotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "WarehauseId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId",
                principalTable: "Warehauses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "WarehauseId",
                table: "HotelLinens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId",
                principalTable: "Warehauses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
