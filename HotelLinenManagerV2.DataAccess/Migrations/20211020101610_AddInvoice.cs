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
                table: "LaundryServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfInvoice = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaundryServices_InvoiceId",
                table: "LaundryServices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_LaundryServices_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "LaundryServices");
        }
    }
}
