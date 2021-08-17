﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RMNCAH_api.Data;

namespace RMNCAH_api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RMNCAH_api.Models.Client.ClientClinicalDetails", b =>
                {
                    b.Property<Guid>("ClientClinicalDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("client_clinical_details_id")
                        .HasColumnType("uuid");

                    b.Property<string>("BabyName")
                        .HasColumnName("baby_name")
                        .HasColumnType("text");

                    b.Property<Guid>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Remarks")
                        .HasColumnName("remarks")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("updated_by")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("updated_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("anc1")
                        .HasColumnName("anc1")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("anc2")
                        .HasColumnName("anc2")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("anc3")
                        .HasColumnName("anc3")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("anc4")
                        .HasColumnName("anc4")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("anc5")
                        .HasColumnName("anc5")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("edd")
                        .HasColumnName("edd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("mr1")
                        .HasColumnName("mr1")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("penta1")
                        .HasColumnName("penta1")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("penta2")
                        .HasColumnName("penta2")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("penta3")
                        .HasColumnName("penta3")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("sba")
                        .HasColumnName("sba")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ClientClinicalDetailsId")
                        .HasName("pk_client_clinical_details");

                    b.ToTable("client_clinical_details");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Client.ClientDetails", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("client_id")
                        .HasColumnType("uuid");

                    b.Property<string>("AlternativePhoneNumber")
                        .HasColumnName("alternative_phone_number")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DOB")
                        .HasColumnName("dob")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FullNames")
                        .HasColumnName("full_names")
                        .HasColumnType("text");

                    b.Property<string>("OtherHFAttended")
                        .HasColumnName("other_hf_attended")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("updated_by")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("updated_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Village")
                        .HasColumnName("village")
                        .HasColumnType("text");

                    b.Property<string>("chvName")
                        .HasColumnName("chv_name")
                        .HasColumnType("text");

                    b.Property<string>("deptClientId")
                        .HasColumnName("dept_client_id")
                        .HasColumnType("text");

                    b.Property<int?>("mfl_code")
                        .HasColumnName("mfl_code")
                        .HasColumnType("integer");

                    b.HasKey("ClientId")
                        .HasName("pk_client_details");

                    b.HasIndex("mfl_code")
                        .HasName("ix_client_details_mfl_code");

                    b.ToTable("client_details");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = "2bb88694-a613-4cb1-b540-61b86713a098",
                            ConcurrencyStamp = "3722be51-6685-47cb-95c1-508ee7be938d",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnName("role_id")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasName("ix_role_claims_role_id");

                    b.ToTable("role_claims");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<int>("ChangePassword")
                        .HasColumnName("change_password")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("text");

                    b.Property<string>("JobTitle")
                        .HasColumnName("job_title")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                            AccessFailedCount = 0,
                            Active = false,
                            ChangePassword = 0,
                            ConcurrencyStamp = "93ca7a61-72b5-487e-aec4-9476a2dfea05",
                            Email = "admin@myemail.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MYEMAIL.COM",
                            NormalizedUserName = "ADMIN@MYEMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDcoat5HJD5rFjNkeAtivGyChdKloL+mZjYXYm1zdOm4cHb5MaNkgAuOuzCBlRbp3A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@myemail.com"
                        });
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasName("ix_user_claims_user_id");

                    b.ToTable("user_claims");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id")
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasName("ix_user_logins_user_id");

                    b.ToTable("user_logins");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ix_user_roles_role_id");

                    b.ToTable("user_roles");

                    b.HasData(
                        new
                        {
                            UserId = "46ba742f-f729-4bb3-81f3-ad4e07c9cd30",
                            RoleId = "2bb88694-a613-4cb1-b540-61b86713a098"
                        });
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("user_tokens");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Utils.HealthFacilities", b =>
                {
                    b.Property<int>("MFLCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("mfl_code")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FacilityName")
                        .HasColumnName("facility_name")
                        .HasColumnType("text");

                    b.HasKey("MFLCode")
                        .HasName("pk_health_facility");

                    b.ToTable("health_facilities");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Client.ClientDetails", b =>
                {
                    b.HasOne("RMNCAH_api.Models.Utils.HealthFacilities", "HFLinked")
                        .WithMany()
                        .HasForeignKey("mfl_code")
                        .HasConstraintName("fk_client_details_health_facility_mfl_code");
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.RoleClaim", b =>
                {
                    b.HasOne("RMNCAH_api.Models.Security.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claims_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserClaim", b =>
                {
                    b.HasOne("RMNCAH_api.Models.Security.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claims_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserLogin", b =>
                {
                    b.HasOne("RMNCAH_api.Models.Security.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_logins_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserRole", b =>
                {
                    b.HasOne("RMNCAH_api.Models.Security.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RMNCAH_api.Models.Security.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RMNCAH_api.Models.Security.UserToken", b =>
                {
                    b.HasOne("RMNCAH_api.Models.Security.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_tokens_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
