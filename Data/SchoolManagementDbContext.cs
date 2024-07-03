using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementApp.MVC.Data;

public partial class SchoolManagementDbContext : DbContext
{
    public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enroll> Enrolls { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC075C09A185");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Classes__CourseI__4AB81AF0");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK__Classes__Lecture__49C3F6B7");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07110A2F9D");

            entity.HasIndex(e => e.Code, "UQ__Courses__A25C5AA72F0AF6DB").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Enroll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enroll__3214EC07CF8E59FE");

            entity.ToTable("Enroll");

            entity.Property(e => e.Grade).HasMaxLength(2);

            entity.HasOne(d => d.Class).WithMany(p => p.Enrolls)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Enroll__ClassId__5629CD9C");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrolls)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Enroll__StudentI__5535A963");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lectures__3214EC076F3AF35B");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0705792788");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
