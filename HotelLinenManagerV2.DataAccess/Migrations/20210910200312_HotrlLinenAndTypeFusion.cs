using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class HotrlLinenAndTypeFusion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_HotelLinenTypes_HotelLinenTypeId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_HotelLinenTypeId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "HotelLinenTypes");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "HotelLinenTypes");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "HotelLinenTypes");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "HotelLinenTypes");

            migrationBuilder.DropColumn(
                name: "HotelLinenTypeId",
                table: "HotelLinens");

            migrationBuilder.RenameColumn(
                name: "NameWithShortDescription",
                table: "HotelLinens",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "HotelLinenTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<string>(
                name: "PricePerKg",
                table: "HotelLinens",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "HotelLinens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeName",
                table: "HotelLinens",
                type: "int",
                maxLength: 80,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "HotelLinens",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "HotelLinens");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "HotelLinens",
                newName: "NameWithShortDescription");

            migrationBuilder.AlterColumn<byte>(
                name: "TypeName",
                table: "HotelLinenTypes",
                type: "tinyint",
                maxLength: 80,
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricePerKg",
                table: "HotelLinenTypes",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "HotelLinenTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tax",
                table: "HotelLinenTypes",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "HotelLinenTypes",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

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
    }
}
