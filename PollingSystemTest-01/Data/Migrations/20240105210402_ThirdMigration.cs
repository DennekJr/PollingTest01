using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestVoteCount",
                table: "Questions");

            migrationBuilder.AddColumn<bool>(
                name: "MostVoted",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "disPlayPercentage",
                table: "Questions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MostVoted",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "disPlayPercentage",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "HighestVoteCount",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
