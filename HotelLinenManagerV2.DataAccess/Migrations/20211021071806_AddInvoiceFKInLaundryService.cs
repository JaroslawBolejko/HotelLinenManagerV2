using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddInvoiceFKInLaundryService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "LaundryServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "LaundryServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
