using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddColumnsInCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Invoices_InvoiceId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_InvoiceId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Company",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Company",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Company",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Company",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Company",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Company",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompanyInvoice",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    InvoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInvoice", x => new { x.CompaniesId, x.InvoicesId });
                    table.ForeignKey(
                        name: "FK_CompanyInvoice_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyInvoice_Invoices_InvoicesId",
                        column: x => x.InvoicesId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInvoice_InvoicesId",
                table: "CompanyInvoice",
                column: "InvoicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInvoice");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_InvoiceId",
                table: "Company",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Invoices_InvoiceId",
                table: "Company",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
