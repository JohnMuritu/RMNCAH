using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class remarksDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "044674a7-6025-4aec-98c8-61517ca1bd6a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "f97836bf-e7d2-4f8b-9aa7-1c34cede1cad");

            migrationBuilder.AddColumn<DateTime>(
                name: "adult_remarks_date",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "delivery_date",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "remarks_child_date",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "e2a978a8-28db-4df6-8c67-47e4c61b9879");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "5a42f1a9-467a-4fd7-b6e6-f238535bf1c9", "d5ade189-5b8a-487b-8aed-c02e933986e8", "REPORT", "REPORT" },
                    { "14348ab4-72f0-443d-b41e-11f4019c907e", "01086a56-81a1-45d3-9b31-aeb4310ac079", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "b47aff5f-002e-4d5b-9ec6-81cd09ab70a0", "AQAAAAEAACcQAAAAEDKImaSjGVukdnhOIEbNmkEItNWQnNKNDyJ7kO2QN2rnogav+rUNzqGO2zZSLbmRyw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "14348ab4-72f0-443d-b41e-11f4019c907e");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "5a42f1a9-467a-4fd7-b6e6-f238535bf1c9");

            migrationBuilder.DropColumn(
                name: "adult_remarks_date",
                table: "client_clinical_details");

            migrationBuilder.DropColumn(
                name: "delivery_date",
                table: "client_clinical_details");

            migrationBuilder.DropColumn(
                name: "remarks_child_date",
                table: "client_clinical_details");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "2ff36c14-7970-4065-b32c-84b05e2ed7ca");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "f97836bf-e7d2-4f8b-9aa7-1c34cede1cad", "2068fb7e-2950-46da-bf91-fee14e8a89c6", "REPORT", "REPORT" },
                    { "044674a7-6025-4aec-98c8-61517ca1bd6a", "5335c665-11ec-4e6c-af15-2a290a04b67e", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "9b5fb56a-6ea8-4138-a551-410a5113b6cf", "AQAAAAEAACcQAAAAEGn9PjsVUbr8Rb2IHlN019SJQAvt9SXQWZPqReDmfJx60xkd1gloUTxRERp7T3I2JA==" });
        }
    }
}
