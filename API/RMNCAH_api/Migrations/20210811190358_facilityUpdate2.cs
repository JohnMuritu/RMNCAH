using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class facilityUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_client_details_health_facility_hf_linked_mfl_code",
                table: "client_details");

            migrationBuilder.DropIndex(
                name: "ix_client_details_hf_linked_mfl_code",
                table: "client_details");

            migrationBuilder.DropColumn(
                name: "hf_linked_mfl_code",
                table: "client_details");

            migrationBuilder.AddColumn<int>(
                name: "mfl_code",
                table: "client_details",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_client_details_mfl_code",
                table: "client_details",
                column: "mfl_code");

            migrationBuilder.AddForeignKey(
                name: "fk_client_details_health_facility_mfl_code",
                table: "client_details",
                column: "mfl_code",
                principalTable: "health_facilities",
                principalColumn: "mfl_code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_client_details_health_facility_mfl_code",
                table: "client_details");

            migrationBuilder.DropIndex(
                name: "ix_client_details_mfl_code",
                table: "client_details");

            migrationBuilder.DropColumn(
                name: "mfl_code",
                table: "client_details");

            migrationBuilder.AddColumn<int>(
                name: "hf_linked_mfl_code",
                table: "client_details",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_client_details_hf_linked_mfl_code",
                table: "client_details",
                column: "hf_linked_mfl_code");

            migrationBuilder.AddForeignKey(
                name: "fk_client_details_health_facility_hf_linked_mfl_code",
                table: "client_details",
                column: "hf_linked_mfl_code",
                principalTable: "health_facilities",
                principalColumn: "mfl_code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
