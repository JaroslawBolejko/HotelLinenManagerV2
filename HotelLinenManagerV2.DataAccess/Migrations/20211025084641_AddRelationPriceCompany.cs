using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddRelationPriceCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "PriceLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_LaundryId",
                table: "PriceLists",
                column: "LaundryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Companies_LaundryId",
                table: "PriceLists",
                column: "LaundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Companies_LaundryId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_LaundryId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "PriceLists");
        }
    }
}
