using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OTUS_Homework_2.Entity;

namespace OTUS_Homework_2;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CoursesTeacher> CoursesTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("courses_pkey");

            entity.ToTable("courses");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.NameCourse).HasColumnName("name_course");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<CoursesTeacher>(entity =>
        {
            entity.HasKey(e => e.CoursesTeachersId).HasName("courses_teachers_pkey");

            entity.ToTable("courses_teachers");

            entity.Property(e => e.CoursesTeachersId).HasColumnName("courses_teachers_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Course).WithMany(p => p.CoursesTeachers)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("courses_teachers_course_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.CoursesTeachers)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("courses_teachers_teacher_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teachers_pkey");

            entity.ToTable("teachers");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.NameTeacher)
                .HasMaxLength(40)
                .HasColumnName("name_teacher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
