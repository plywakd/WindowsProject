using Microsoft.EntityFrameworkCore.Migrations;

namespace backendProject.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_WritingText_textToWriteWritingTextID",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Game_GameID",
                table: "Result");

            migrationBuilder.RenameColumn(
                name: "WritingTextID",
                table: "WritingText",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Result",
                newName: "gameID");

            migrationBuilder.RenameColumn(
                name: "ResultID",
                table: "Result",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Result_GameID",
                table: "Result",
                newName: "IX_Result_gameID");

            migrationBuilder.RenameColumn(
                name: "textToWriteWritingTextID",
                table: "Game",
                newName: "textToWriteID");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Game",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Game_textToWriteWritingTextID",
                table: "Game",
                newName: "IX_Game_textToWriteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_WritingText_textToWriteID",
                table: "Game",
                column: "textToWriteID",
                principalTable: "WritingText",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Game_gameID",
                table: "Result",
                column: "gameID",
                principalTable: "Game",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_WritingText_textToWriteID",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Game_gameID",
                table: "Result");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "WritingText",
                newName: "WritingTextID");

            migrationBuilder.RenameColumn(
                name: "gameID",
                table: "Result",
                newName: "GameID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Result",
                newName: "ResultID");

            migrationBuilder.RenameIndex(
                name: "IX_Result_gameID",
                table: "Result",
                newName: "IX_Result_GameID");

            migrationBuilder.RenameColumn(
                name: "textToWriteID",
                table: "Game",
                newName: "textToWriteWritingTextID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Game",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Game_textToWriteID",
                table: "Game",
                newName: "IX_Game_textToWriteWritingTextID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_WritingText_textToWriteWritingTextID",
                table: "Game",
                column: "textToWriteWritingTextID",
                principalTable: "WritingText",
                principalColumn: "WritingTextID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Game_GameID",
                table: "Result",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
