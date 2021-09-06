using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddCompanyReferanceToHotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComapnyId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_CompanyId",
                table: "HotelLinens",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Companies_CompanyId",
                table: "HotelLinens",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Companies_CompanyId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_CompanyId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "ComapnyId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "HotelLinens");
        }
    }
}
