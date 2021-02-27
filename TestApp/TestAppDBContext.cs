using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestApp
{
    public partial class TestAppDBContext : DbContext
    {
        public TestAppDBContext()
        {
        }

        public TestAppDBContext(DbContextOptions<TestAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Completedtest> Completedtests { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestAppDB;Username=postgres;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Completedtestid).HasColumnName("completedtestid");

                entity.Property(e => e.Questionid).HasColumnName("questionid");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Completedtest)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Completedtestid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("answer_completedtestid_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Questionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("answer_questionid_fkey");
            });

            modelBuilder.Entity<Completedtest>(entity =>
            {
                entity.ToTable("completedtest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Testid).HasColumnName("testid");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Completedtests)
                    .HasForeignKey(d => d.Personid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("completedtest_personid_fkey");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Completedtests)
                    .HasForeignKey(d => d.Testid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("completedtest_testid_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer1)
                    .IsRequired()
                    .HasColumnName("answer1");

                entity.Property(e => e.Answer2)
                    .IsRequired()
                    .HasColumnName("answer2");

                entity.Property(e => e.Answer3)
                    .IsRequired()
                    .HasColumnName("answer3");

                entity.Property(e => e.Questionbody)
                    .IsRequired()
                    .HasColumnName("questionbody");

                entity.Property(e => e.Rigthanswer).HasColumnName("rigthanswer");

                entity.Property(e => e.Testid).HasColumnName("testid");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Testid)
                    .HasConstraintName("question_testid_fkey");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("date")
                    .HasColumnName("creationdate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
