using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DailyMenuModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DailyMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstDishId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SecondDishId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyMenu_Items_FirstDishId",
                        column: x => x.FirstDishId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyMenu_Items_SecondDishId",
                        column: x => x.SecondDishId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenu_FirstDishId",
                table: "DailyMenu",
                column: "FirstDishId",
                unique: true,
                filter: "[FirstDishId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenu_SecondDishId",
                table: "DailyMenu",
                column: "SecondDishId",
                unique: true,
                filter: "[SecondDishId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMenu");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");
        }
    }
}
