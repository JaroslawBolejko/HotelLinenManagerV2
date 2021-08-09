using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddWarehauseDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WarehauseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelLinenId = table.Column<int>(type: "int", nullable: false),
                    WarehauseId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehauseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehauseDetails_HotelLinens_HotelLinenId",
                        column: x => x.HotelLinenId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehauseDetails_Warehauses_WarehauseId",
                        column: x => x.WarehauseId,
                        principalTable: "Warehauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehauseDetails_HotelLinenId",
                table: "WarehauseDetails",
                column: "HotelLinenId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehauseDetails_WarehauseId",
                table: "WarehauseDetails",
                column: "WarehauseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehauseDetails");

            migrationBuilder.AddColumn<int>(
                name: "WarehauseId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Warehauses_WarehauseId",
                table: "HotelLinens",
                column: "WarehauseId",
                principalTable: "Warehauses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
