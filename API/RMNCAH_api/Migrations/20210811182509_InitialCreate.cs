using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RMNCAH_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_clinical_details",
                columns: table => new
                {
                    client_clinical_details_id = table.Column<Guid>(nullable: false),
                    client_id = table.Column<Guid>(nullable: false),
                    anc1 = table.Column<DateTime>(nullable: true),
                    anc2 = table.Column<DateTime>(nullable: true),
                    anc3 = table.Column<DateTime>(nullable: true),
                    anc4 = table.Column<DateTime>(nullable: true),
                    anc5 = table.Column<DateTime>(nullable: true),
                    edd = table.Column<DateTime>(nullable: true),
                    sba = table.Column<DateTime>(nullable: true),
                    penta1 = table.Column<DateTime>(nullable: true),
                    penta2 = table.Column<DateTime>(nullable: true),
                    penta3 = table.Column<DateTime>(nullable: true),
                    mr1 = table.Column<DateTime>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(nullable: true),
                    updated_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_clinical_details", x => x.client_clinical_details_id);
                });

            migrationBuilder.CreateTable(
                name: "health_facilities",
                columns: table => new
                {
                    mfl_code = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facility_name = table.Column<string>(nullable: true),
                    facility_type = table.Column<string>(nullable: true),
                    facility_owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_health_facility", x => x.mfl_code);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    change_password = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_details",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    full_names = table.Column<string>(nullable: true),
                    dob = table.Column<DateTime>(nullable: false),
                    village = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    alternative_phone_number = table.Column<string>(nullable: true),
                    hf_linked_mfl_code = table.Column<int>(nullable: true),
                    other_hf_attended = table.Column<string>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(nullable: true),
                    updated_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_details", x => x.client_id);
                    table.ForeignKey(
                        name: "fk_client_details_health_facility_hf_linked_mfl_code",
                        column: x => x.hf_linked_mfl_code,
                        principalTable: "health_facilities",
                        principalColumn: "mfl_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    role_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "2bb88694-a613-4cb1-b540-61b86713a098", "98948637-0818-4a5f-bc9d-84585ec13b8f", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "active", "change_password", "concurrency_stamp", "email", "email_confirmed", "first_name", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { "46ba742f-f729-4bb3-81f3-ad4e07c9cd30", 0, false, 0, "c4b2ec84-fefd-4103-9226-e12d248ade3f", "admin@myemail.com", true, "Admin", "Admin", false, null, "ADMIN@MYEMAIL.COM", "ADMIN@MYEMAIL.COM", "AQAAAAEAACcQAAAAEI/qPWbJQclS9O/TV1S0jwOF/eTjMjgzupQY1cm/I6rT8Yo8cIVXFkYYYqwePrpoGQ==", null, false, "", false, "admin@myemail.com" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "user_id", "role_id" },
                values: new object[] { "46ba742f-f729-4bb3-81f3-ad4e07c9cd30", "2bb88694-a613-4cb1-b540-61b86713a098" });

            migrationBuilder.CreateIndex(
                name: "ix_client_details_hf_linked_mfl_code",
                table: "client_details",
                column: "hf_linked_mfl_code");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_logins_user_id",
                table: "user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_clinical_details");

            migrationBuilder.DropTable(
                name: "client_details");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "health_facilities");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
