using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "job_title",
                table: "users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "588ff086-3836-4881-8062-e2a682b1aba1");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "d668c6a7-0cb1-44c2-a5dc-49d1710ca188", "AQAAAAEAACcQAAAAEPlNxWT6+SKFt/ohCUNvCNjrqSCJt7jAjOv3WjkSA5J3gHRGhZm7EwCmIe9YMY/MzQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "job_title",
                table: "users");

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
    }
}
