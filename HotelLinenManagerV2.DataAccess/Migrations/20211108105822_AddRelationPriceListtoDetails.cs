using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddRelationPriceListtoDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceListId",
                table: "PriceListDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetails_PriceListId",
                table: "PriceListDetails",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListDetails_PriceLists_PriceListId",
                table: "PriceListDetails",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListDetails_PriceLists_PriceListId",
                table: "PriceListDetails");

            migrationBuilder.DropIndex(
                name: "IX_PriceListDetails_PriceListId",
                table: "PriceListDetails");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "PriceListDetails");
        }
    }
}
