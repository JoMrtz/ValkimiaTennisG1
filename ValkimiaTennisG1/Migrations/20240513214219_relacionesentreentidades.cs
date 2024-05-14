using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValkimiaTennisG1.Migrations
{
    /// <inheritdoc />
    public partial class relacionesentreentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Winner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => new { x.MatchId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PlayerId",
                table: "MatchPlayer",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match");

            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Match",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "id");
        }
    }
}
