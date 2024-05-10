using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValkimiaTennisG1.Migrations
{
    /// <inheritdoc />
    public partial class migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Player",
                type: "int",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "Player",
                type: "int",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ReactionTime",
                table: "Player",
                type: "int",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Player",
                type: "int",
                maxLength: 2,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "Player",
                type: "int",
                maxLength: 2,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReactionTime",
                table: "Player",
                type: "int",
                maxLength: 2,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
