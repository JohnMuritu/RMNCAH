using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class ClientDetailsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "chv_name",
                table: "client_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dept_client_id",
                table: "client_details",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "2061c43d-620e-4fcf-aae0-474850a18712");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "156df0f4-394f-4a53-8d31-10809b2763a7", "AQAAAAEAACcQAAAAEOh45sWZy420AS0nIXnjBiSxUMdzd9YxLi8Cnf4XtJLPU3AOHgp6ONXy72nctKUBUw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chv_name",
                table: "client_details");

            migrationBuilder.DropColumn(
                name: "dept_client_id",
                table: "client_details");

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
    }
}
