using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class remarksParentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "remarks_parent_date",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "2da2f64a-be7c-4585-aaf6-8f5faf631f6c");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "b652ecd0-19ae-434b-9dea-1a9e28f753ac", "ba81a4b9-356f-4f15-ae1e-827d48bab577", "REPORT", "REPORT" },
                    { "1d63151c-6113-4641-a6b4-f3c252912ce0", "c9a8b314-c953-4a53-b6fd-908fe7a5b425", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "d0d585f2-61eb-4668-a795-8163e51c300f", "AQAAAAEAACcQAAAAEGvZwvr5FeZVbQRqIwveC7n2i0gsdC9X0RwqW9m81gGGVyhXldjgzo9RzPIQIgz5ow==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "1d63151c-6113-4641-a6b4-f3c252912ce0");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "b652ecd0-19ae-434b-9dea-1a9e28f753ac");

            migrationBuilder.DropColumn(
                name: "remarks_parent_date",
                table: "client_clinical_details");

            migrationBuilder.AddColumn<DateTime>(
                name: "adult_remarks_date",
                table: "client_clinical_details",
                type: "timestamp without time zone",
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
    }
}
