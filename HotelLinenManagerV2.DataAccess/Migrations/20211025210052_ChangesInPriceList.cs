using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class ChangesInPriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_PriceLists_PriceId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Companies_LaundryId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_PriceId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "PricePerKg",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "LaundryId",
                table: "PriceLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "PriceLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "PriceLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PriceLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocName",
                table: "PriceLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocNumber",
                table: "PriceLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_CompanyId",
                table: "PriceLists",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_CompanyId1",
                table: "PriceLists",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Companies_CompanyId",
                table: "PriceLists",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Companies_CompanyId1",
                table: "PriceLists",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Companies_LaundryId",
                table: "PriceLists",
                column: "LaundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Companies_CompanyId",
                table: "PriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Companies_CompanyId1",
                table: "PriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Companies_LaundryId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_CompanyId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_CompanyId1",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "DocName",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "DocNumber",
                table: "PriceLists");

            migrationBuilder.AlterColumn<int>(
                name: "LaundryId",
                table: "PriceLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerKg",
                table: "PriceLists",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TaxValue",
                table: "PriceLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_PriceId",
                table: "HotelLinens",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_PriceLists_PriceId",
                table: "HotelLinens",
                column: "PriceId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Companies_LaundryId",
                table: "PriceLists",
                column: "LaundryId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
