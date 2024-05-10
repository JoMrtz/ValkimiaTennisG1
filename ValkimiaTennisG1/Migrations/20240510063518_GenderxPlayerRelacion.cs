using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValkimiaTennisG1.Migrations
{
    /// <inheritdoc />
    public partial class GenderxPlayerRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "id", "GenderType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_GenderId",
                table: "Player",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Gender_GenderId",
                table: "Player",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Gender_GenderId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_Player_GenderId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Player");
        }
    }
}
