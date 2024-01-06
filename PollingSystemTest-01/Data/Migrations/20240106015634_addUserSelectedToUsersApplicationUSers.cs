using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class addUserSelectedToUsersApplicationUSers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UsersSelected",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersSelected_ApplicationUserId",
                table: "UsersSelected",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSelected_AspNetUsers_ApplicationUserId",
                table: "UsersSelected",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSelected_AspNetUsers_ApplicationUserId",
                table: "UsersSelected");

            migrationBuilder.DropIndex(
                name: "IX_UsersSelected_ApplicationUserId",
                table: "UsersSelected");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UsersSelected");
        }
    }
}
