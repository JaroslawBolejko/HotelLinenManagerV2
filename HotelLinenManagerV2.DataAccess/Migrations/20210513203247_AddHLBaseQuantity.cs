using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddHLBaseQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HLBaseQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelLinenId = table.Column<int>(type: "int", nullable: false),
                    HotelLinenBaseQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HLBaseQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HLBaseQuantities_HotelLinens_HotelLinenId",
                        column: x => x.HotelLinenId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HLBaseQuantities_HotelLinenId",
                table: "HLBaseQuantities",
                column: "HotelLinenId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HLBaseQuantities");
        }
    }
}
