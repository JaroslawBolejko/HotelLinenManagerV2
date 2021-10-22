using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class PriceListsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoices_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_PriceId",
                table: "HotelLinens",
                column: "PriceId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_PriceList_PriceId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_LaundryServices_Invoice_InvoiceId",
                table: "LaundryServices");

            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_PriceId",
                table: "HotelLinens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "HotelLinens");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

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
