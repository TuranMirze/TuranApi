using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Api.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWord_Word_WordId",
                table: "BannedWord");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Languages_LanguageCode",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_Languages_LangCode",
                table: "Word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Word",
                table: "Word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_LanguageCode",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Word",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Word_LangCode",
                table: "Words",
                newName: "IX_Words_LangCode");

            migrationBuilder.AlterColumn<string>(
                name: "LangCode",
                table: "Games",
                type: "nchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LangCode",
                table: "Games",
                column: "LangCode");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWord_Words_WordId",
                table: "BannedWord",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Languages_LangCode",
                table: "Games",
                column: "LangCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Languages_LangCode",
                table: "Words",
                column: "LangCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWord_Words_WordId",
                table: "BannedWord");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Languages_LangCode",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Languages_LangCode",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LangCode",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "Word");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_Words_LangCode",
                table: "Word",
                newName: "IX_Word_LangCode");

            migrationBuilder.AlterColumn<string>(
                name: "LangCode",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(2)");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "Game",
                type: "nchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Word",
                table: "Word",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Game_LanguageCode",
                table: "Game",
                column: "LanguageCode");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWord_Word_WordId",
                table: "BannedWord",
                column: "WordId",
                principalTable: "Word",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Languages_LanguageCode",
                table: "Game",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Languages_LangCode",
                table: "Word",
                column: "LangCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
