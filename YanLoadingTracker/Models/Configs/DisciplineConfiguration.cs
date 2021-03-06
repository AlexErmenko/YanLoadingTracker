﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YanLoadingTracker.Models
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> entity)
        {
            entity.HasKey(e => e.Id)
                .HasName("Discipline_pk")
                .IsClustered(false);

            entity.ToTable("Discipline");

            entity.HasComment("Дисциплины");

            entity.HasIndex(e => e.Id)
                .HasName("Discipline_Id_uindex")
                .IsUnique();

            entity.Property(e => e.Name).IsRequired();

            entity.HasOne(d => d.IdCourseNavigation)
                .WithMany(p => p.Disciplines)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Discipline_Course_Id_fk");
        }
    }
}
