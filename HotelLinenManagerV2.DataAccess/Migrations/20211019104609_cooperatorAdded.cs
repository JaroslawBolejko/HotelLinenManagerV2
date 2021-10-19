using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class cooperatorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooperators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCooperator",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    CooperatorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCooperator", x => new { x.CompaniesId, x.CooperatorsId });
                    table.ForeignKey(
                        name: "FK_CompanyCooperator_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCooperator_Cooperators_CooperatorsId",
                        column: x => x.CooperatorsId,
                        principalTable: "Cooperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCooperator_CooperatorsId",
                table: "CompanyCooperator",
                column: "CooperatorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyCooperator");

            migrationBuilder.DropTable(
                name: "Cooperators");
        }
    }
}
