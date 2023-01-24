using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRIDGamE.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bec561d7-cb44-4130-8afc-92a63afe293b", "e01d4858-8d16-4693-b3b8-8dc6dbe8a105", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbed936d-e515-4e03-a577-3c860f95ef26", "2ba8dc4b-896e-4612-8b17-87e99d4cd605", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec561d7-cb44-4130-8afc-92a63afe293b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbed936d-e515-4e03-a577-3c860f95ef26");
        }
    }
}
