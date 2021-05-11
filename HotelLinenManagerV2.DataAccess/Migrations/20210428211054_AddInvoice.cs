using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceTotal = table.Column<double>(type: "float", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelLinenWeight = table.Column<int>(type: "int", nullable: false),
                    PricePerKg = table.Column<int>(type: "int", nullable: false),
                    Tax = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_InvoiceId",
                table: "HotelLinens",
                column: "InvoiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Invoices_InvoiceId",
                table: "HotelLinens",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Invoices_InvoiceId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Invoices_InvoiceId",
                table: "HotelLinens");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_InvoiceId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_Company_InvoiceId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Company");
        }
    }
}
