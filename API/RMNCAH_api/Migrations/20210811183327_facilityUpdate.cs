using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class facilityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "facility_owner",
                table: "health_facilities");

            migrationBuilder.DropColumn(
                name: "facility_type",
                table: "health_facilities");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "7eeaf675-5382-45f0-8294-a5efb8b3fc6d");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "f506edf3-0c2c-4936-a361-789c58cf8181", "AQAAAAEAACcQAAAAECYgMFCqvLViF502ppCedxyJjRrluQiT2NzqGyCwxRB9FUECtCqQBRdmR1r4lIG2pw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "facility_owner",
                table: "health_facilities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facility_type",
                table: "health_facilities",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "98948637-0818-4a5f-bc9d-84585ec13b8f");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "c4b2ec84-fefd-4103-9226-e12d248ade3f", "AQAAAAEAACcQAAAAEI/qPWbJQclS9O/TV1S0jwOF/eTjMjgzupQY1cm/I6rT8Yo8cIVXFkYYYqwePrpoGQ==" });
        }
    }
}
