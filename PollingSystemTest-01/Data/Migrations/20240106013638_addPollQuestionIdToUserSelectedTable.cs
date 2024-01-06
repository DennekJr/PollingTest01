using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class addPollQuestionIdToUserSelectedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSelected_Questions_PollQuestionId",
                table: "UsersSelected");

            migrationBuilder.AlterColumn<int>(
                name: "PollQuestionId",
                table: "UsersSelected",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSelected_Questions_PollQuestionId",
                table: "UsersSelected",
                column: "PollQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSelected_Questions_PollQuestionId",
                table: "UsersSelected");

            migrationBuilder.AlterColumn<int>(
                name: "PollQuestionId",
                table: "UsersSelected",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSelected_Questions_PollQuestionId",
                table: "UsersSelected",
                column: "PollQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
