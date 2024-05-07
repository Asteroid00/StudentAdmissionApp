﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentAdmissionAppApi.Models
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stages> Stages { get; set; }
        public virtual DbSet<Standards> Standards { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stages>(entity =>
            {
                entity.HasKey(e => e.StageId)
                    .HasName("PK__Stages__03EB7AD80BD5AB62");

                entity.Property(e => e.StageDescription).IsUnicode(false);

                entity.Property(e => e.StageName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Standards>(entity =>
            {
                entity.HasKey(e => e.StandardId);

                entity.Property(e => e.ClassTeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StandardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Standards)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Standards_Standards");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Biology).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Chemistry).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateOfApplication).HasColumnType("date");

                entity.Property(e => e.English).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hindi).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Maths).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Percentages).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Physics).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Science).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SocialStudies).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StudentEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMarks).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Stages");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StandardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Standards");
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}