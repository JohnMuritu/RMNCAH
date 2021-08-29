using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class Updatechvs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "28a092e1-85a5-4ee1-9f78-6b6d8c8bfd23");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "5548f605-07ea-443b-89e4-21e97dba6b8a");

            migrationBuilder.AlterColumn<string>(
                name: "active",
                table: "chvs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "33aeb9ec-db4b-4540-bce0-03438d6ecb9a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "b9c89f23-b94c-49de-8cdd-d407a6ef56b3");

            migrationBuilder.AlterColumn<int>(
                name: "active",
                table: "chvs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "efe034ef-2618-46b8-b474-db0f9f85481d");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "28a092e1-85a5-4ee1-9f78-6b6d8c8bfd23", "4d0c5483-c663-4ac2-8c13-b56c02ee15be", "REPORT", "REPORT" },
                    { "5548f605-07ea-443b-89e4-21e97dba6b8a", "38cd3704-3e0e-4aab-9c90-dc044e9109de", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "cfa54844-5c44-4b94-a384-a823903ae66e", "AQAAAAEAACcQAAAAEL+vI1cexMUVy9pnkWsHKaWVyCRiCXwe2FtYeDzJAzXpZOdrthhzTXJ+MW7utgG3XA==" });
        }
    }
}
