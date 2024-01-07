using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class seedDataWorkingAdminUserTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b44b257-5d56-4930-b6ad-7fd77abe7ade", "ADMIN@GMAIL@COM", "ADMIN@GMAIL@COM", "AQAAAAEAACcQAAAAEHmCfihUaYJ08bzpJbOKPJchfDo6M2n2D5YJE8G2J7eTmJKFBDYkms2uqpBSRU/CiQ==", "fec50712-0d81-4702-9f2b-7cf00cbecd0f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faf9af62-4ace-4821-91ea-7f2187d2b217", null, null, "AQAAAAEAACcQAAAAEEet+6q1IIg5E115382AKn+F7+K2YQXxqeFRXABzv5fmgc447Amsv0vCUeO8sMXZSg==", "0ed86163-da57-47d2-be54-92aa948abd6e" });
        }
    }
}
