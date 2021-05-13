using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class ValidationInhotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_LaundryServices_LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "LaundryServiceId",
                table: "HotelLinens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_LaundryServices_LaundryServiceId",
                table: "HotelLinens",
                column: "LaundryServiceId",
                principalTable: "LaundryServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_LaundryServices_LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "LaundryServiceId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_LaundryServices_LaundryServiceId",
                table: "HotelLinens",
                column: "LaundryServiceId",
                principalTable: "LaundryServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
