using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class DeleteHotelLineIdInWareHause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehauses_HotelLinens_HotelLinenId",
                table: "Warehauses");

            migrationBuilder.AlterColumn<int>(
                name: "HotelLinenId",
                table: "Warehauses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehauses_HotelLinens_HotelLinenId",
                table: "Warehauses",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehauses_HotelLinens_HotelLinenId",
                table: "Warehauses");

            migrationBuilder.AlterColumn<int>(
                name: "HotelLinenId",
                table: "Warehauses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehauses_HotelLinens_HotelLinenId",
                table: "Warehauses",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
