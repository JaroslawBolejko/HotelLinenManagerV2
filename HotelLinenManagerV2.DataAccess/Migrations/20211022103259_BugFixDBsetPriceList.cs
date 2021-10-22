using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class BugFixDBsetPriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_PriceList_PriceId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoice_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceList",
                table: "PriceList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "PriceList",
                newName: "PriceLists");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceLists",
                table: "PriceLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_PriceLists_PriceId",
                table: "HotelLinens",
                column: "PriceId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_HotelLinens_PriceLists_PriceId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceLists",
                table: "PriceLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "PriceLists",
                newName: "PriceList");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceList",
                table: "PriceList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_PriceList_PriceId",
                table: "HotelLinens",
                column: "PriceId",
                principalTable: "PriceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryServices_Invoice_InvoiceId",
                table: "LaundryServices",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
