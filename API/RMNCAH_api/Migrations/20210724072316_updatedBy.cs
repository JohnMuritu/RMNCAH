using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class updatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "client_details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "client_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "db6e329d-cbf8-4e2f-b351-ae5bd78705e5");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "144d3631-cdc8-4cf5-8549-2707ec281135", "AQAAAAEAACcQAAAAEMTxghCuWwRhUFZ20EkSVuHcOlmRvCrTFhLLlE4m7RSIMlSYokL9OzwN7mNhxcvujw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "client_details");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "client_details");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "client_clinical_details");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "client_clinical_details");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "66a758f6-b1fe-4b9c-8a17-0dc38b775195");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "14959d3d-bf99-4171-8362-8fff19d00157", "AQAAAAEAACcQAAAAEOCLS8KXTAO/mAZLoqgSd8LsIFq0hBxuyqah5jQdtcciW2mXrcl3M6WwikxhwhKQcw==" });
        }
    }
}
