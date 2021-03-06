﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YanLoadingTracker.Models
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> entity)
        {
            entity.HasKey(e => e.Id)
                .HasName("Teachers_pk")
                .IsClustered(false);

            entity.ToTable("Teacher");

            entity.HasComment("Преподаватели");

            entity.HasIndex(e => e.Id)
                .HasName("Teachers_Id_uindex")
                .IsUnique();

            entity.Property(e => e.FirstName).IsRequired();

            entity.Property(e => e.LastName).IsRequired();

            entity.Property(e => e.MiddleName).IsRequired();

            entity.HasOne(d => d.IdDepartmentNavigation)
                .WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("Teacher_Department_Id_fk");
        }
    }
}
