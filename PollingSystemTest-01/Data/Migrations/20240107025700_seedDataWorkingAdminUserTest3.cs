using Microsoft.EntityFrameworkCore.Migrations;

namespace PollingSystemTest_01.Data.Migrations
{
    public partial class seedDataWorkingAdminUserTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcc5966e-aeb2-4c34-9920-db605f4de955", "AQAAAAEAACcQAAAAEMotftc/V3N+vfbtEyOub7GPkhvDHo/3tquRixvhjUHyfzydjKR/J8ij6bS99DLpQw==", "6ae2340b-d72d-4de6-a903-9c83f65eaddb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b44b257-5d56-4930-b6ad-7fd77abe7ade", "AQAAAAEAACcQAAAAEHmCfihUaYJ08bzpJbOKPJchfDo6M2n2D5YJE8G2J7eTmJKFBDYkms2uqpBSRU/CiQ==", "fec50712-0d81-4702-9f2b-7cf00cbecd0f" });
        }
    }
}
