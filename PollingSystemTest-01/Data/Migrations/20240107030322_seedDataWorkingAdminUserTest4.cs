using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class seedDataWorkingAdminUserTest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5266dc2a-a63e-4261-8f7a-e8157c791c1d", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEP0LrBqW56+LD7WpYYeJQQDFs70JwEgPERvX/+ArytVJhoZUjlQMTmjD4yCLXvizsA==", "a8d55bdd-b08e-4115-9029-484fd09d37a8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcc5966e-aeb2-4c34-9920-db605f4de955", "ADMIN@GMAIL@COM", "ADMIN@GMAIL@COM", "AQAAAAEAACcQAAAAEMotftc/V3N+vfbtEyOub7GPkhvDHo/3tquRixvhjUHyfzydjKR/J8ij6bS99DLpQw==", "6ae2340b-d72d-4de6-a903-9c83f65eaddb" });
        }
    }
}
