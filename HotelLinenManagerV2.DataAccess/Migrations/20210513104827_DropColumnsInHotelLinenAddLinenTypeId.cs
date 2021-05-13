using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class DropColumnsInHotelLinenAddLinenTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenTypeId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_HotelLinenTypeId",
                table: "HotelLinens",
                column: "HotelLinenTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_HotelLinenTypes_HotelLinenTypeId",
                table: "HotelLinens",
                column: "HotelLinenTypeId",
                principalTable: "HotelLinenTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_HotelLinenTypes_HotelLinenTypeId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_HotelLinenTypeId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "HotelLinenTypeId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<short>(
                name: "Amount",
                table: "HotelLinens",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PricePerKg",
                table: "HotelLinens",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tax",
                table: "HotelLinens",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "HotelLinens",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }
    }
}
