using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace backendProject.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Last_logged = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WritingText",
                columns: table => new
                {
                    WritingTextID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: true),
                    source = table.Column<string>(type: "text", nullable: true),
                    topSpeed = table.Column<double>(type: "double precision", nullable: false),
                    averageSpeed = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingText", x => x.WritingTextID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gameName = table.Column<string>(type: "text", nullable: true),
                    textToWriteWritingTextID = table.Column<int>(type: "integer", nullable: true),
                    wordCount = table.Column<int>(type: "integer", nullable: false),
                    minWordspeed = table.Column<double>(type: "double precision", nullable: false),
                    maxMistakes = table.Column<int>(type: "integer", nullable: false),
                    difficulty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Game_WritingText_textToWriteWritingTextID",
                        column: x => x.textToWriteWritingTextID,
                        principalTable: "WritingText",
                        principalColumn: "WritingTextID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameID = table.Column<int>(type: "integer", nullable: true),
                    wordSpeed = table.Column<double>(type: "double precision", nullable: false),
                    accountID = table.Column<int>(type: "integer", nullable: true),
                    finish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isPassed = table.Column<bool>(type: "boolean", nullable: false),
                    mistakes = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_Result_Account_accountID",
                        column: x => x.accountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Result_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_textToWriteWritingTextID",
                table: "Game",
                column: "textToWriteWritingTextID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_accountID",
                table: "Result",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_GameID",
                table: "Result",
                column: "GameID");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "WritingText");
        }
    }
}
