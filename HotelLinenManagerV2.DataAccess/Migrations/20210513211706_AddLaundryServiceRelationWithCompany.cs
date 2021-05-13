using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddLaundryServiceRelationWithCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyLaundryService",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    LaundryServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLaundryService", x => new { x.CompaniesId, x.LaundryServicesId });
                    table.ForeignKey(
                        name: "FK_CompanyLaundryService_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyLaundryService_LaundryServices_LaundryServicesId",
                        column: x => x.LaundryServicesId,
                        principalTable: "LaundryServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLaundryService_LaundryServicesId",
                table: "CompanyLaundryService",
                column: "LaundryServicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyLaundryService");
        }
    }
}
