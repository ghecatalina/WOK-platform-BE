using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfPeople",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "Reservations",
                newName: "TableId");

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Number", "Size" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 2, 3 },
                    { 3, 3, 2 },
                    { 4, 4, 8 },
                    { 5, 5, 10 },
                    { 6, 6, 4 },
                    { 7, 7, 4 },
                    { 8, 8, 6 },
                    { 9, 9, 2 },
                    { 10, 10, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Reservations",
                newName: "TableNumber");

            migrationBuilder.AddColumn<int>(
                name: "NoOfPeople",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
