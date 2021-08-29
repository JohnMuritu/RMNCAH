using Microsoft.EntityFrameworkCore.Migrations;

namespace RMNCAH_api.Migrations
{
    public partial class UpdateClientdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "323cc680-949d-41a3-92bd-9af259be1ce6");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "6eb6b784-d98f-4ffd-b22a-f77a852999af");

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

            migrationBuilder.CreateIndex(
                name: "ix_client_details_chv_id",
                table: "client_details",
                column: "chv_id");

            migrationBuilder.AddForeignKey(
                name: "fk_client_details_chvs_chv_id",
                table: "client_details",
                column: "chv_id",
                principalTable: "chvs",
                principalColumn: "chv_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_client_details_chvs_chv_id",
                table: "client_details");

            migrationBuilder.DropIndex(
                name: "ix_client_details_chv_id",
                table: "client_details");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "044674a7-6025-4aec-98c8-61517ca1bd6a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "f97836bf-e7d2-4f8b-9aa7-1c34cede1cad");

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
    }
}
