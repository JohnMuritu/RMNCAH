using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class defaultersReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "1d63151c-6113-4641-a6b4-f3c252912ce0");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "b652ecd0-19ae-434b-9dea-1a9e28f753ac");

            migrationBuilder.CreateTable(
                name: "defaulters",
                columns: table => new
                {
                    client_clinical_details_id = table.Column<Guid>(nullable: false),
                    full_names = table.Column<string>(nullable: true),
                    dept_client_id = table.Column<string>(nullable: true),
                    facility_name = table.Column<string>(nullable: true),
                    edd = table.Column<DateTime>(nullable: true),
                    delivery = table.Column<string>(nullable: true),
                    delivery_date = table.Column<DateTime>(nullable: true),
                    delivery_defaulter = table.Column<string>(nullable: true),
                    penta1 = table.Column<DateTime>(nullable: true),
                    penta1defaulter = table.Column<string>(nullable: true),
                    penta3 = table.Column<DateTime>(nullable: true),
                    penta3defaulter = table.Column<string>(nullable: true),
                    mr1 = table.Column<DateTime>(nullable: true),
                    mr1defaulter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_defaulters", x => x.client_clinical_details_id);
                });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "86058ec6-635c-4904-b3f0-07d96861ad99");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "b0ffd149-2abf-40e8-b49f-a58383146684", "7e4f7d86-d5a5-4a14-9b7d-aa31fa345070", "REPORT", "REPORT" },
                    { "029f93f3-4a32-4508-8620-072745a1d54f", "cf440651-d6ec-492c-8287-ec08cb345836", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "1e32cb06-d162-4af5-b579-042786b8957a", "AQAAAAEAACcQAAAAECwGaQrwyS2Pf5XMiXmQnCPAkIsD/gEAc1k42YzzjMu9S04iT5WBB0JbncdgQlzmTw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "defaulters");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "029f93f3-4a32-4508-8620-072745a1d54f");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "b0ffd149-2abf-40e8-b49f-a58383146684");

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
    }
}
