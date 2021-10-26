﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddPriceDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceListDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<int>(type: "int", nullable: false),
                    HotelLinenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetails_HotelLinens_HotelLinenId",
                        column: x => x.HotelLinenId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetails_HotelLinenId",
                table: "PriceListDetails",
                column: "HotelLinenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceListDetails");
        }
    }
}
