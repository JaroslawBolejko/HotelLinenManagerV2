using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    public partial class AddLaundryService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaundryServiceId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LaundryServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecievedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundryServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_LaundryServiceId",
                table: "HotelLinens",
                column: "LaundryServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_LaundryServices_LaundryServiceId",
                table: "HotelLinens",
                column: "LaundryServiceId",
                principalTable: "LaundryServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_LaundryServices_LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.DropTable(
                name: "LaundryServices");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "LaundryServiceId",
                table: "HotelLinens");
        }
    }
}
