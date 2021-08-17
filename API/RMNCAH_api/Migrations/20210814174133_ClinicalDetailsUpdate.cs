using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class ClinicalDetailsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "b6f4114b-82d9-48d4-8cb9-56425b552ec8");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "bd0d4175-d068-458c-91af-ad1ce7660f83", "AQAAAAEAACcQAAAAECvFdoKyorMFALJSlf7APVnLIvyuKxREOXDPDWQq2d1gknsBsLBKf4QRv3gYxsF5Gg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "a722eacd-afed-4402-bef2-5371df042ed3");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "4b41162e-e45c-4484-b3b1-c38c80b4ea79", "AQAAAAEAACcQAAAAEOP9EMaSaMt8loCW2VO5upurFR8GYiIOi9ffFQNdW01OE6+J0u6QUlWweQ0clqN/JQ==" });
        }
    }
}
