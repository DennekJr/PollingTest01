using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class seedDataWorkingAdminUserTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "faf9af62-4ace-4821-91ea-7f2187d2b217", "AQAAAAEAACcQAAAAEEet+6q1IIg5E115382AKn+F7+K2YQXxqeFRXABzv5fmgc447Amsv0vCUeO8sMXZSg==", "Admin", "0ed86163-da57-47d2-be54-92aa948abd6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                column: "NormalizedName",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "64397d4b-fcda-45db-a4de-2bc429b1a4f6", "AQAAAAEAACcQAAAAEItazwobT9c9a9lyi2DxH1oBiuTVlE0Ch6GtOQbjCkDTOZq8y4mOtqwf/ZQFXP5iSA==", null, "cfe9f0d8-800a-457f-958f-d3d879563b2d" });
        }
    }
}
