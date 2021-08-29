using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class UpdateClientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "33aeb9ec-db4b-4540-bce0-03438d6ecb9a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "b9c89f23-b94c-49de-8cdd-d407a6ef56b3");

            migrationBuilder.DropColumn(
                name: "chv_name",
                table: "client_details");

            migrationBuilder.AddColumn<int>(
                name: "chv_id",
                table: "client_details",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "942b38f2-33e3-491b-8e2a-62f993a22ce3");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "6eb6b784-d98f-4ffd-b22a-f77a852999af", "6b43c224-8613-4859-9a65-8687444b1902", "REPORT", "REPORT" },
                    { "323cc680-949d-41a3-92bd-9af259be1ce6", "9fbc43a4-18fc-42d3-a05b-5e5952ade84c", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "5b1c439c-0784-4f54-95cd-ace0752b443f", "AQAAAAEAACcQAAAAEJ/RdjbNYXmM939k5GWREh8wvuDPgN0sJR8ORexdJ+CdDFtAjw3a5olSuwcc0f5czQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "323cc680-949d-41a3-92bd-9af259be1ce6");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "6eb6b784-d98f-4ffd-b22a-f77a852999af");

            migrationBuilder.DropColumn(
                name: "chv_id",
                table: "client_details");

            migrationBuilder.AddColumn<string>(
                name: "chv_name",
                table: "client_details",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "7912fef6-00a2-4722-bde4-683ce9e4e8f4");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "b9c89f23-b94c-49de-8cdd-d407a6ef56b3", "5e635772-3af7-4f0f-997d-f040b1712d47", "REPORT", "REPORT" },
                    { "33aeb9ec-db4b-4540-bce0-03438d6ecb9a", "1b04d895-883c-4196-8b10-41bfe237397f", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "13be0e3a-f052-418d-946d-de33054e45f3", "AQAAAAEAACcQAAAAELC2kb+e51ErL7UA679vjRtFnHG6ejT2uaYye01Pvpife67imiCYyImrod7ISdxjBw==" });
        }
    }
}
