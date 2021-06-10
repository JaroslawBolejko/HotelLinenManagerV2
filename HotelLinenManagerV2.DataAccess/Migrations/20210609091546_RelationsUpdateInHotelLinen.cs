using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class RelationsUpdateInHotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelLinenWarehause");

            migrationBuilder.DropIndex(
                name: "IX_HLBaseQuantities_HotelLinenId",
                table: "HLBaseQuantities");

            migrationBuilder.AddColumn<int>(
                name: "WarehauseId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId");

            migrationBuilder.CreateIndex(
                name: "IX_HLBaseQuantities_HotelLinenId",
                table: "HLBaseQuantities",
                column: "HotelLinenId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId",
                principalTable: "Warehauses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HLBaseQuantities_HotelLinenId",
                table: "HLBaseQuantities");

            migrationBuilder.DropColumn(
                name: "WarehauseId",
                table: "HotelLinens");

            migrationBuilder.CreateTable(
                name: "HotelLinenWarehause",
                columns: table => new
                {
                    HotelLinensId = table.Column<int>(type: "int", nullable: false),
                    WarehausesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLinenWarehause", x => new { x.HotelLinensId, x.WarehausesId });
                    table.ForeignKey(
                        name: "FK_HotelLinenWarehause_HotelLinens_HotelLinensId",
                        column: x => x.HotelLinensId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelLinenWarehause_Warehauses_WarehausesId",
                        column: x => x.WarehausesId,
                        principalTable: "Warehauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HLBaseQuantities_HotelLinenId",
                table: "HLBaseQuantities",
                column: "HotelLinenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinenWarehause_WarehausesId",
                table: "HotelLinenWarehause",
                column: "WarehausesId");
        }
    }
}
