using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddedBankaccountToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Companies");
        }
    }
}
