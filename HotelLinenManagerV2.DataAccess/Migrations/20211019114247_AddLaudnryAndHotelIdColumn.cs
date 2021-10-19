using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddLaudnryAndHotelIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "LaundryServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaundryServices_LaundryId",
                table: "LaundryServices",
                column: "LaundryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryServices_Companies_LaundryId",
                table: "LaundryServices",
                column: "LaundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Companies_LaundryId",
                table: "LaundryServices");

            migrationBuilder.DropIndex(
                name: "IX_LaundryServices_LaundryId",
                table: "LaundryServices");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "LaundryServices");
        }
    }
}
