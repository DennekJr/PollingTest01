using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectVoteCount",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PollOptionIsCorrect",
                table: "Options");

            migrationBuilder.AddColumn<int>(
                name: "HighestVoteCount",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PollOptionVoteCount",
                table: "Options",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestVoteCount",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PollOptionVoteCount",
                table: "Options");

            migrationBuilder.AddColumn<int>(
                name: "CorrectVoteCount",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PollOptionIsCorrect",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
