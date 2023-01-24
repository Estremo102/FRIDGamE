using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRIDGamE.Migrations
{
    public partial class hotfixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartOfPromotion",
                table: "Promotions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartOfPromotion",
                table: "Promotions");
        }
    }
}
