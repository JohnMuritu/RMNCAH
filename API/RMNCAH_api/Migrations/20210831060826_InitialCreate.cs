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
                name: "adult_remarks_options",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adult_remarks_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "child_remarks_options",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_child_remarks_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chvs",
                columns: table => new
                {
                    chv_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chv_name = table.Column<string>(nullable: true),
                    active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chvs", x => x.chv_id);
                });

            migrationBuilder.CreateTable(
                name: "client_details_and_clinical_report_data",
                columns: table => new
                {
                    client_clinical_details_id = table.Column<Guid>(nullable: false),
                    chv_name = table.Column<string>(nullable: true),
                    dept_client_id = table.Column<string>(nullable: true),
                    full_names = table.Column<string>(nullable: true),
                    age = table.Column<double>(nullable: false),
                    village = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    alternative_phone_number = table.Column<string>(nullable: true),
                    hf_linked = table.Column<string>(nullable: true),
                    other_hf_attended = table.Column<string>(nullable: true),
                    baby_name = table.Column<string>(nullable: true),
                    anc1 = table.Column<DateTime>(nullable: true),
                    anc2 = table.Column<DateTime>(nullable: true),
                    anc3 = table.Column<DateTime>(nullable: true),
                    anc4 = table.Column<DateTime>(nullable: true),
                    anc5 = table.Column<DateTime>(nullable: true),
                    edd = table.Column<DateTime>(nullable: true),
                    remarks_parent = table.Column<string>(nullable: true),
                    delivery = table.Column<string>(nullable: true),
                    penta1 = table.Column<DateTime>(nullable: true),
                    penta2 = table.Column<DateTime>(nullable: true),
                    penta3 = table.Column<DateTime>(nullable: true),
                    mr1 = table.Column<DateTime>(nullable: true),
                    remarks_child = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_details_and_clinical_report_data", x => x.client_clinical_details_id);
                });

            migrationBuilder.CreateTable(
                name: "clinical_aggregated_summary",
                columns: table => new
                {
                    total_anc1 = table.Column<int>(nullable: false),
                    total_anc2 = table.Column<int>(nullable: false),
                    total_anc3 = table.Column<int>(nullable: false),
                    total_anc4 = table.Column<int>(nullable: false),
                    total_anc5 = table.Column<int>(nullable: false),
                    total_edd = table.Column<int>(nullable: false),
                    total_penta1 = table.Column<int>(nullable: false),
                    total_penta2 = table.Column<int>(nullable: false),
                    total_penta3 = table.Column<int>(nullable: false),
                    total_mr1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

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
                    penta1_defaulter = table.Column<string>(nullable: true),
                    penta3 = table.Column<DateTime>(nullable: true),
                    penta3_defaulter = table.Column<string>(nullable: true),
                    mr1 = table.Column<DateTime>(nullable: true),
                    mr1_defaulter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_defaulters", x => x.client_clinical_details_id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_options",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_delivery_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "health_facilities",
                columns: table => new
                {
                    mfl_code = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facility_name = table.Column<string>(nullable: true)
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
                name: "user_sign_up_resource",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    job_title = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    user_role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_sign_up_resource", x => x.user_id);
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
                    active = table.Column<bool>(nullable: false),
                    job_title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_clinical_details",
                columns: table => new
                {
                    client_clinical_details_id = table.Column<Guid>(nullable: false),
                    client_id = table.Column<Guid>(nullable: false),
                    baby_name = table.Column<string>(nullable: true),
                    anc1 = table.Column<DateTime>(nullable: true),
                    anc2 = table.Column<DateTime>(nullable: true),
                    anc3 = table.Column<DateTime>(nullable: true),
                    anc4 = table.Column<DateTime>(nullable: true),
                    anc5 = table.Column<DateTime>(nullable: true),
                    edd = table.Column<DateTime>(nullable: true),
                    remarks_parent = table.Column<int>(nullable: true),
                    remarks_parent_date = table.Column<DateTime>(nullable: true),
                    delivery = table.Column<int>(nullable: true),
                    delivery_date = table.Column<DateTime>(nullable: true),
                    penta1 = table.Column<DateTime>(nullable: true),
                    penta2 = table.Column<DateTime>(nullable: true),
                    penta3 = table.Column<DateTime>(nullable: true),
                    mr1 = table.Column<DateTime>(nullable: true),
                    remarks_child = table.Column<int>(nullable: true),
                    remarks_child_date = table.Column<DateTime>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(nullable: true),
                    updated_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_clinical_details", x => x.client_clinical_details_id);
                    table.ForeignKey(
                        name: "fk_client_clinical_details_delivery_options_delivery",
                        column: x => x.delivery,
                        principalTable: "delivery_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_client_clinical_details_child_remarks_options_remarks_child",
                        column: x => x.remarks_child,
                        principalTable: "child_remarks_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_client_clinical_details_adult_remarks_options_remarks_parent",
                        column: x => x.remarks_parent,
                        principalTable: "adult_remarks_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client_details",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    chv_id = table.Column<int>(nullable: false),
                    dept_client_id = table.Column<string>(nullable: true),
                    full_names = table.Column<string>(nullable: true),
                    dob = table.Column<DateTime>(nullable: false),
                    village = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    alternative_phone_number = table.Column<string>(nullable: true),
                    mfl_code = table.Column<int>(nullable: false),
                    other_hf_attended = table.Column<string>(nullable: true),
                    hiv_status_known = table.Column<string>(nullable: true),
                    test_done = table.Column<string>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(nullable: true),
                    updated_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_details", x => x.client_id);
                    table.ForeignKey(
                        name: "fk_client_details_chvs_chv_id",
                        column: x => x.chv_id,
                        principalTable: "chvs",
                        principalColumn: "chv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_details_health_facility_mfl_code",
                        column: x => x.mfl_code,
                        principalTable: "health_facilities",
                        principalColumn: "mfl_code",
                        onDelete: ReferentialAction.Cascade);
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
                table: "adult_remarks_options",
                columns: new[] { "id", "option" },
                values: new object[,]
                {
                    { 1, "Abortion" },
                    { 2, "Miscarriage" },
                    { 3, "Still birth" },
                    { 4, "Maternal death" }
                });

            migrationBuilder.InsertData(
                table: "child_remarks_options",
                columns: new[] { "id", "option" },
                values: new object[] { 1, "Child death" });

            migrationBuilder.InsertData(
                table: "delivery_options",
                columns: new[] { "id", "option" },
                values: new object[,]
                {
                    { 1, "SBA" },
                    { 2, "HD (home delivery)" },
                    { 3, "BBA(Born before arrival)" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "2bb88694-a613-4cb1-b540-61b86713a098", "57c92f93-50c5-45e2-b50f-b4026aa4b4a2", "ADMIN", "ADMIN" },
                    { "72e01fca-ebdb-49bc-b379-3bba3c740b13", "f57ede2f-7829-4fce-baf2-7d8f042e9b88", "REPORT", "REPORT" },
                    { "0ada5ef0-d21b-43cc-a34a-c64cbd0e2f60", "2553aa91-3bb5-4a7c-ae91-cce34dd8561a", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "active", "change_password", "concurrency_stamp", "email", "email_confirmed", "first_name", "job_title", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { "46ba742f-f729-4bb3-81f3-ad4e07c9cd30", 0, true, 0, "9de19191-7f30-4b14-9e9c-7aa9f80cc782", "admin@myemail.com", true, "Admin", "System Administrator", "Admin", false, null, "ADMIN@MYEMAIL.COM", "ADMIN@MYEMAIL.COM", "AQAAAAEAACcQAAAAEBs93+IOCYSV2uifWW4Kw3HhxWEY4TQRfjSfruL03CcdXN3o2MVawTpp+sYbvmEzmg==", null, false, "", false, "admin@myemail.com" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "user_id", "role_id" },
                values: new object[] { "46ba742f-f729-4bb3-81f3-ad4e07c9cd30", "2bb88694-a613-4cb1-b540-61b86713a098" });

            migrationBuilder.CreateIndex(
                name: "ix_client_clinical_details_delivery",
                table: "client_clinical_details",
                column: "delivery");

            migrationBuilder.CreateIndex(
                name: "ix_client_clinical_details_remarks_child",
                table: "client_clinical_details",
                column: "remarks_child");

            migrationBuilder.CreateIndex(
                name: "ix_client_clinical_details_remarks_parent",
                table: "client_clinical_details",
                column: "remarks_parent");

            migrationBuilder.CreateIndex(
                name: "ix_client_details_chv_id",
                table: "client_details",
                column: "chv_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_details_mfl_code",
                table: "client_details",
                column: "mfl_code");

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
                name: "client_details_and_clinical_report_data");

            migrationBuilder.DropTable(
                name: "clinical_aggregated_summary");

            migrationBuilder.DropTable(
                name: "defaulters");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_sign_up_resource");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "delivery_options");

            migrationBuilder.DropTable(
                name: "child_remarks_options");

            migrationBuilder.DropTable(
                name: "adult_remarks_options");

            migrationBuilder.DropTable(
                name: "chvs");

            migrationBuilder.DropTable(
                name: "health_facilities");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
