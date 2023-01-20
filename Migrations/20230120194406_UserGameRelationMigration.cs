using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRIDGamE.Migrations
{
    public partial class UserGameRelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "FRIDGamEUserGame",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRIDGamEUserGame", x => new { x.GamesId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_FRIDGamEUserGame_AspNetUsers_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FRIDGamEUserGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FRIDGamEUserGame_OwnersId",
                table: "FRIDGamEUserGame",
                column: "OwnersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FRIDGamEUserGame");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");
        }
    }
}
