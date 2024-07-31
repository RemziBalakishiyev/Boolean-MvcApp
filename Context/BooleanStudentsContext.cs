using System;
using System.Collections.Generic;
using BooleanşMvcApp.Tables;
using Microsoft.EntityFrameworkCore;

namespace BooleanşMvcApp.Context;

public partial class BooleanStudentsContext : DbContext
{
    public BooleanStudentsContext()
    {
    }

    public BooleanStudentsContext(DbContextOptions<BooleanStudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExamineResult> ExamineResults { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwStudenResult> VwStudenResults { get; set; }

    public virtual DbSet<VwStudentDetail> VwStudentDetails { get; set; }

    public virtual DbSet<VwStudentExam> VwStudentExams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=BooleanStudents;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExamineResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EXAMINE___3214EC273F4293CF");

            entity.ToTable("EXAMINE_RESULTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("EXAM_DATE");
            entity.Property(e => e.Result).HasColumnName("RESULT");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
            entity.Property(e => e.SubjectId).HasColumnName("SUBJECT_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamineResults)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__EXAMINE_R__STUDE__70DDC3D8");

            entity.HasOne(d => d.Subject).WithMany(p => p.ExamineResults)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("SUBJECT_ID");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GENDERS__3214EC2793CA0C20");

            entity.ToTable("GENDERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GROUPS__3214EC2738C75541");

            entity.ToTable("GROUPS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("NAME");

            entity.HasMany(d => d.Subjects).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GROUP_SUB__SUBJE__46E78A0C"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GROUP_SUB__GROUP__45F365D3"),
                    j =>
                    {
                        j.HasKey("GroupId", "SubjectId").HasName("PK__GROUP_SU__51778D348E220399");
                        j.ToTable("GROUP_SUBJECTS");
                        j.IndexerProperty<int>("GroupId").HasColumnName("GROUP_ID");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("SUBJECT_ID");
                    });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("STUDENTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.GenderId).HasColumnName("GENDER_ID");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("PATRONYMIC");

            entity.HasOne(d => d.Gender).WithMany(p => p.Students)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_STUDENTS_GENDERS");
        });

        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STUDENT___3214EC27227E39CB");

            entity.ToTable("STUDENT_DETAILS");

            entity.HasIndex(e => e.StudentId, "UQ__STUDENT___E69FE77ABDE34594").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcceptPoint).HasColumnName("ACCEPT_POINT");
            entity.Property(e => e.BirthPlace)
                .HasMaxLength(50)
                .HasColumnName("BIRTH_PLACE");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

            entity.HasOne(d => d.Student).WithOne(p => p.StudentDetail)
                .HasForeignKey<StudentDetail>(d => d.StudentId)
                .HasConstraintName("FK__STUDENT_D__STUDE__412EB0B6");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SUBJECTS__3214EC27793DF932");

            entity.ToTable("SUBJECTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HoursOfLesson).HasColumnName("HOURS_OF_LESSON");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3214EC271B22FF4F");

            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.WebSiteUrl)
                .HasMaxLength(50)
                .HasColumnName("WEB_SITE_URL");
        });

        modelBuilder.Entity<VwStudenResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_STUDEN_RESULTS");

            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.AvgLesson).HasColumnName("AVG_LESSON");
            entity.Property(e => e.AvgResult).HasColumnName("AVG_RESULT");
            entity.Property(e => e.FullName)
                .HasMaxLength(40)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
        });

        modelBuilder.Entity<VwStudentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_STUDENT_DETAILS");

            entity.Property(e => e.AcceptPoint).HasColumnName("ACCEPT_POINT");
            entity.Property(e => e.FullName)
                .HasMaxLength(101)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.GroupName)
                .HasMaxLength(20)
                .HasColumnName("GROUP_NAME");
            entity.Property(e => e.Result).HasColumnName("RESULT");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(60)
                .HasColumnName("SUBJECT_NAME");
        });

        modelBuilder.Entity<VwStudentExam>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_STUDENT_EXAMS");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("NAME");
            entity.Property(e => e.Result).HasColumnName("RESULT");
            entity.Property(e => e.ResultName)
                .HasMaxLength(5)
                .HasColumnName("RESULT_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
