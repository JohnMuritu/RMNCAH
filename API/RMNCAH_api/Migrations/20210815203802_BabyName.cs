using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class BabyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "baby_name",
                table: "client_clinical_details",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "3722be51-6685-47cb-95c1-508ee7be938d");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "93ca7a61-72b5-487e-aec4-9476a2dfea05", "AQAAAAEAACcQAAAAEDcoat5HJD5rFjNkeAtivGyChdKloL+mZjYXYm1zdOm4cHb5MaNkgAuOuzCBlRbp3A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "baby_name",
                table: "client_clinical_details");

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
    }
}
