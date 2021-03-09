﻿// <auto-generated />
using System;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(bp6pznqoywrjk82ucfnmContext))]
    [Migration("20210309174109_identitypeleas")]
    partial class identitypeleas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Database.Models.Answers", b =>
                {
                    b.Property<int>("IdAnswer")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_answer")
                        .HasColumnType("int(11)");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnName("answer")
                        .HasColumnType("varchar(450)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<int>("IdQuestion")
                        .HasColumnName("id_question")
                        .HasColumnType("int(11)");

                    b.HasKey("IdAnswer")
                        .HasName("PRIMARY");

                    b.HasIndex("IdQuestion")
                        .HasName("id_question");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("Database.Models.Evaluations", b =>
                {
                    b.Property<int>("IdEvaluation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_evaluation")
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("varchar(450)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdEvaluation")
                        .HasName("PRIMARY");

                    b.ToTable("evaluations");
                });

            modelBuilder.Entity("Database.Models.Files", b =>
                {
                    b.Property<int>("IdFiles")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_files")
                        .HasColumnType("int(11)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnName("file_name")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<int>("IdUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int(11)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnName("path")
                        .HasColumnType("varchar(200)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdFiles")
                        .HasName("PRIMARY");

                    b.ToTable("files");
                });

            modelBuilder.Entity("Database.Models.InternTeam", b =>
                {
                    b.Property<int>("IdInternt")
                        .HasColumnName("id_internt")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdTeam")
                        .HasColumnName("id_team")
                        .HasColumnType("int(11)");

                    b.HasIndex("IdTeam")
                        .HasName("id_team");

                    b.HasIndex("IdInternt", "IdTeam")
                        .HasName("id_internt");

                    b.ToTable("intern_team");
                });

            modelBuilder.Entity("Database.Models.Interns", b =>
                {
                    b.Property<int>("IdInternt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_internt")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnName("cedula")
                        .HasColumnType("varchar(15)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Cv")
                        .HasColumnName("cv")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Github")
                        .HasColumnName("github")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnName("id_user")
                        .HasColumnType("varchar(450)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Linkedin")
                        .HasColumnName("linkedin")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasColumnType("varchar(12)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("UserImg")
                        .HasColumnName("user_img")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdInternt")
                        .HasName("PRIMARY");

                    b.HasIndex("IdUser")
                        .HasName("id_user");

                    b.ToTable("interns");
                });

            modelBuilder.Entity("Database.Models.Internship", b =>
                {
                    b.Property<int>("IdInternship")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_internship")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("varchar(450)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<bool>("Status")
                        .HasColumnName("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdInternship")
                        .HasName("PRIMARY");

                    b.ToTable("internship");
                });

            modelBuilder.Entity("Database.Models.Questions", b =>
                {
                    b.Property<int>("IdQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_question")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdEvaluation")
                        .HasColumnName("id_evaluation")
                        .HasColumnType("int(11)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnName("question")
                        .HasColumnType("varchar(450)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdQuestion")
                        .HasName("PRIMARY");

                    b.HasIndex("IdEvaluation")
                        .HasName("id_evaluation");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("Database.Models.RequestInternship", b =>
                {
                    b.Property<int>("IdRequestInternship")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_request_internship")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<int>("Cedula")
                        .HasColumnName("cedula")
                        .HasColumnType("int(15)");

                    b.Property<string>("Cv")
                        .IsRequired()
                        .HasColumnName("cv")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Github")
                        .IsRequired()
                        .HasColumnName("github")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<int>("IdInternship")
                        .HasColumnName("id_internship")
                        .HasColumnType("int(11)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .HasColumnName("linkedin")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<int>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("int(12)");

                    b.HasKey("IdRequestInternship")
                        .HasName("PRIMARY");

                    b.HasIndex("IdInternship")
                        .HasName("id_internship");

                    b.ToTable("request_internship");
                });

            modelBuilder.Entity("Database.Models.Results", b =>
                {
                    b.Property<int>("IdResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_result")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdEvaluation")
                        .HasColumnName("id_evaluation")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdIntern")
                        .HasColumnName("id_intern")
                        .HasColumnType("int(11)");

                    b.HasKey("IdResult")
                        .HasName("PRIMARY");

                    b.HasIndex("IdIntern")
                        .HasName("id_intern");

                    b.HasIndex("IdEvaluation", "IdIntern")
                        .HasName("id_evaluation");

                    b.ToTable("results");
                });

            modelBuilder.Entity("Database.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_team")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdInternship")
                        .HasColumnName("id_internship")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdTeam")
                        .HasName("PRIMARY");

                    b.HasIndex("IdInternship")
                        .HasName("id_internship");

                    b.ToTable("team");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Database.Models.Answers", b =>
                {
                    b.HasOne("Database.Models.Questions", "IdQuestionNavigation")
                        .WithMany("Answers")
                        .HasForeignKey("IdQuestion")
                        .HasConstraintName("answers_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.InternTeam", b =>
                {
                    b.HasOne("Database.Models.Interns", "IdInterntNavigation")
                        .WithMany()
                        .HasForeignKey("IdInternt")
                        .HasConstraintName("intern_team_ibfk_1")
                        .IsRequired();

                    b.HasOne("Database.Models.Team", "IdTeamNavigation")
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .HasConstraintName("intern_team_ibfk_2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Questions", b =>
                {
                    b.HasOne("Database.Models.Evaluations", "IdEvaluationNavigation")
                        .WithMany("Questions")
                        .HasForeignKey("IdEvaluation")
                        .HasConstraintName("questions_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.RequestInternship", b =>
                {
                    b.HasOne("Database.Models.Internship", "IdInternshipNavigation")
                        .WithMany("RequestInternship")
                        .HasForeignKey("IdInternship")
                        .HasConstraintName("request_internship_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Results", b =>
                {
                    b.HasOne("Database.Models.Evaluations", "IdEvaluationNavigation")
                        .WithMany("Results")
                        .HasForeignKey("IdEvaluation")
                        .HasConstraintName("results_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Interns", "IdInternNavigation")
                        .WithMany("Results")
                        .HasForeignKey("IdIntern")
                        .HasConstraintName("results_ibfk_2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
