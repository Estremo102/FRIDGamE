using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRIDGamE.Migrations
{
    public partial class GameDescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameStudioId = table.Column<int>(type: "int", nullable: false),
                    GamePublisherId = table.Column<int>(type: "int", nullable: false),
                    RegularPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    EndOfPromotion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Developers_GameStudioId",
                        column: x => x.GameStudioId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promotions_Publishers_GamePublisherId",
                        column: x => x.GamePublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_GamePublisherId",
                table: "Promotions",
                column: "GamePublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_GameStudioId",
                table: "Promotions",
                column: "GameStudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");
        }
    }
}
