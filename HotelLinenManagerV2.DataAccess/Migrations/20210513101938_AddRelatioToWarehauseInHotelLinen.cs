using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddRelatioToWarehauseInHotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehauses_HotelLinens_HotelLinenId",
                table: "Warehauses");

            migrationBuilder.DropIndex(
                name: "IX_Warehauses_HotelLinenId",
                table: "Warehauses");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "Warehauses");

            migrationBuilder.AddColumn<int>(
                name: "WarehauseId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "WarehauseId",
                table: "HotelLinens");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "Warehauses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehauses_HotelLinenId",
                table: "Warehauses",
                column: "HotelLinenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehauses_HotelLinens_HotelLinenId",
                table: "Warehauses",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
