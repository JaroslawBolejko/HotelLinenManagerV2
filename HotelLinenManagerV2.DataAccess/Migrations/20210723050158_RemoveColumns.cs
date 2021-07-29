using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class RemoveColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Companies_HotelId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Companies_LoundryId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_HotelId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_LoundryId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "LoundryId",
                table: "Tests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoundryId",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_HotelId",
                table: "Tests",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LoundryId",
                table: "Tests",
                column: "LoundryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Companies_HotelId",
                table: "Tests",
                column: "HotelId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Companies_LoundryId",
                table: "Tests",
                column: "LoundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
