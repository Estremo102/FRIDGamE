using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRIDGamE.Migrations
{
    public partial class Promotions2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Developers_GameStudioId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Publishers_GamePublisherId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_GamePublisherId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "GamePublisherId",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "GameStudioId",
                table: "Promotions",
                newName: "GameNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Promotions_GameStudioId",
                table: "Promotions",
                newName: "IX_Promotions_GameNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Games_GameNameId",
                table: "Promotions",
                column: "GameNameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Games_GameNameId",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "GameNameId",
                table: "Promotions",
                newName: "GameStudioId");

            migrationBuilder.RenameIndex(
                name: "IX_Promotions_GameNameId",
                table: "Promotions",
                newName: "IX_Promotions_GameStudioId");

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GamePublisherId",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_GamePublisherId",
                table: "Promotions",
                column: "GamePublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Developers_GameStudioId",
                table: "Promotions",
                column: "GameStudioId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Publishers_GamePublisherId",
                table: "Promotions",
                column: "GamePublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
