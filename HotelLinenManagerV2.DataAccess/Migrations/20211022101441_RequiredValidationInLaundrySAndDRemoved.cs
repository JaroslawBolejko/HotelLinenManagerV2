using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class RequiredValidationInLaundrySAndDRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "LaundryServiceDetails");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                table: "LaundryServiceDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PricePerKg",
                table: "LaundryServiceDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TaxValue",
                table: "LaundryServiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
