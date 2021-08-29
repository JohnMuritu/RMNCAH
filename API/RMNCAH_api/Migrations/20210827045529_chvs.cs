using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RMNCAH_api.Migrations
{
    public partial class chvs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "be564fa1-4e18-4f69-9cf2-449907b3e6ab");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "cb85f759-ef4d-4f06-87ce-4d4857f4815d");

            migrationBuilder.CreateTable(
                name: "chvs",
                columns: table => new
                {
                    chv_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chv_name = table.Column<string>(nullable: true),
                    active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chvs", x => x.chv_id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chvs");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "28a092e1-85a5-4ee1-9f78-6b6d8c8bfd23");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "5548f605-07ea-443b-89e4-21e97dba6b8a");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2bb88694-a613-4cb1-b540-61b86713a098",
                column: "concurrency_stamp",
                value: "284ae6e6-7366-47d2-9cb3-9ee837313d71");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "cb85f759-ef4d-4f06-87ce-4d4857f4815d", "30483cad-ce09-469e-b469-95f03fe030b8", "REPORT", "REPORT" },
                    { "be564fa1-4e18-4f69-9cf2-449907b3e6ab", "32729835-d6da-41b1-9b0f-076a19ed9409", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "29a64c5a-f819-454e-8583-2aaed81d5eef", "AQAAAAEAACcQAAAAEBf82WaxkkXjdsRRfTviDrPDNe7fCY4wbkNVodf9ZEb8H6dht/lHMeO00G1eSjCP2A==" });
        }
    }
}
