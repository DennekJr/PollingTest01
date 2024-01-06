using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersSelected");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UsersSelected",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UsersSelected");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersSelected",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
