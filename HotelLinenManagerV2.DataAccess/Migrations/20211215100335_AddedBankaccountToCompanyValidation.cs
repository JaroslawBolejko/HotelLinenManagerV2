using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddedBankaccountToCompanyValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BankAccountNumber",
                table: "Companies",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BankAccountNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldNullable: true);
        }
    }
}
