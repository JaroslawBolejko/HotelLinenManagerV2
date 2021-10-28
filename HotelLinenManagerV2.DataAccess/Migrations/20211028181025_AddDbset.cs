using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedCompany_Companies_CompanyId",
                table: "RelatedCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedCompany_Companies_LaundryId",
                table: "RelatedCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedCompany",
                table: "RelatedCompany");

            migrationBuilder.RenameTable(
                name: "RelatedCompany",
                newName: "RelatedCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedCompany_LaundryId",
                table: "RelatedCompanies",
                newName: "IX_RelatedCompanies_LaundryId");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedCompany_CompanyId",
                table: "RelatedCompanies",
                newName: "IX_RelatedCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedCompanies",
                table: "RelatedCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedCompanies_Companies_CompanyId",
                table: "RelatedCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedCompanies_Companies_LaundryId",
                table: "RelatedCompanies",
                column: "LaundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedCompanies_Companies_CompanyId",
                table: "RelatedCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedCompanies_Companies_LaundryId",
                table: "RelatedCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedCompanies",
                table: "RelatedCompanies");

            migrationBuilder.RenameTable(
                name: "RelatedCompanies",
                newName: "RelatedCompany");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedCompanies_LaundryId",
                table: "RelatedCompany",
                newName: "IX_RelatedCompany_LaundryId");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedCompanies_CompanyId",
                table: "RelatedCompany",
                newName: "IX_RelatedCompany_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedCompany",
                table: "RelatedCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedCompany_Companies_CompanyId",
                table: "RelatedCompany",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedCompany_Companies_LaundryId",
                table: "RelatedCompany",
                column: "LaundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
