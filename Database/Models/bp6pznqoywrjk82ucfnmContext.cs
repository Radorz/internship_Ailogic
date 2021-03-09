using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class bp6pznqoywrjk82ucfnmContext : IdentityDbContext
    {
        public bp6pznqoywrjk82ucfnmContext()
        {
        }

        public bp6pznqoywrjk82ucfnmContext(DbContextOptions<bp6pznqoywrjk82ucfnmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
       
        public virtual DbSet<Evaluations> Evaluations { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<InternTeam> InternTeam { get; set; }
        public virtual DbSet<Interns> Interns { get; set; }
        public virtual DbSet<Internship> Internship { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<RequestInternship> RequestInternship { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=bp6pznqoywrjk82ucfnm-mysql.services.clever-cloud.com;port=3306;uid=u1otsmw6ubwycsab;pwd=1mF2RVzGpTsmNdEiUz4u;database=bp6pznqoywrjk82ucfnm", x => x.ServerVersion("8.0.15-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.IdAnswer)
                    .HasName("PRIMARY");

                entity.ToTable("answers");

                entity.HasIndex(e => e.IdQuestion)
                    .HasName("id_question");

                entity.Property(e => e.IdAnswer)
                    .HasColumnName("id_answer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdQuestion)
                    .HasColumnName("id_question")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("answers_ibfk_1");
            });

            

            modelBuilder.Entity<Evaluations>(entity =>
            {
                entity.HasKey(e => e.IdEvaluation)
                    .HasName("PRIMARY");

                entity.ToTable("evaluations");

                entity.Property(e => e.IdEvaluation)
                    .HasColumnName("id_evaluation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.IdFiles)
                    .HasName("PRIMARY");

                entity.ToTable("files");

                entity.Property(e => e.IdFiles)
                    .HasColumnName("id_files")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<InternTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("intern_team");

                entity.HasIndex(e => e.IdTeam)
                    .HasName("id_team");

                entity.HasIndex(e => new { e.IdInternt, e.IdTeam })
                    .HasName("id_internt");

                entity.Property(e => e.IdInternt)
                    .HasColumnName("id_internt")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTeam)
                    .HasColumnName("id_team")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdInterntNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdInternt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("intern_team_ibfk_1");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTeam)
                    .HasConstraintName("intern_team_ibfk_2");
            });

            modelBuilder.Entity<Interns>(entity =>
            {
                entity.HasKey(e => e.IdInternt)
                    .HasName("PRIMARY");

                entity.ToTable("interns");

                entity.HasIndex(e => e.IdUser)
                    .HasName("id_user");

                entity.Property(e => e.IdInternt)
                    .HasColumnName("id_internt")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasColumnName("cedula")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Cv)
                    .HasColumnName("cv")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Github)
                    .HasColumnName("github")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("id_user")
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Linkedin)
                    .HasColumnName("linkedin")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserImg)
                    .HasColumnName("user_img")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                //entity.HasOne(d => d.IdUserNavigation)
                //    .WithMany(p => p.Interns)
                //    .HasForeignKey(d => d.IdUser)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("interns_ibfk_1");
            });

            modelBuilder.Entity<Internship>(entity =>
            {
                entity.HasKey(e => e.IdInternship)
                    .HasName("PRIMARY");

                entity.ToTable("internship");

                entity.Property(e => e.IdInternship)
                    .HasColumnName("id_internship")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.IdQuestion)
                    .HasName("PRIMARY");

                entity.ToTable("questions");

                entity.HasIndex(e => e.IdEvaluation)
                    .HasName("id_evaluation");

                entity.Property(e => e.IdQuestion)
                    .HasColumnName("id_question")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEvaluation)
                    .HasColumnName("id_evaluation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdEvaluationNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.IdEvaluation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("questions_ibfk_1");
            });

            modelBuilder.Entity<RequestInternship>(entity =>
            {
                entity.HasKey(e => e.IdRequestInternship)
                    .HasName("PRIMARY");

                entity.ToTable("request_internship");

                entity.HasIndex(e => e.IdInternship)
                    .HasName("id_internship");

                entity.Property(e => e.IdRequestInternship)
                    .HasColumnName("id_request_internship")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasColumnType("int(15)");

                entity.Property(e => e.Cv)
                    .IsRequired()
                    .HasColumnName("cv")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Github)
                    .IsRequired()
                    .HasColumnName("github")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdInternship)
                    .HasColumnName("id_internship")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Linkedin)
                    .IsRequired()
                    .HasColumnName("linkedin")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("int(12)");

                entity.HasOne(d => d.IdInternshipNavigation)
                    .WithMany(p => p.RequestInternship)
                    .HasForeignKey(d => d.IdInternship)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_internship_ibfk_1");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => e.IdResult)
                    .HasName("PRIMARY");

                entity.ToTable("results");

                entity.HasIndex(e => e.IdIntern)
                    .HasName("id_intern");

                entity.HasIndex(e => new { e.IdEvaluation, e.IdIntern })
                    .HasName("id_evaluation");

                entity.Property(e => e.IdResult)
                    .HasColumnName("id_result")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEvaluation)
                    .HasColumnName("id_evaluation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdIntern)
                    .HasColumnName("id_intern")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEvaluationNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdEvaluation)
                    .HasConstraintName("results_ibfk_1");

                entity.HasOne(d => d.IdInternNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdIntern)
                    .HasConstraintName("results_ibfk_2");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.IdTeam)
                    .HasName("PRIMARY");

                entity.ToTable("team");

                entity.HasIndex(e => e.IdInternship)
                    .HasName("id_internship");

                entity.Property(e => e.IdTeam)
                    .HasColumnName("id_team")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdInternship)
                    .HasColumnName("id_internship")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
