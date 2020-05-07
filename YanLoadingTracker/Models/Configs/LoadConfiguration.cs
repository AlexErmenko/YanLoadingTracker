﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YanLoadingTracker.Models
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> entity)
        {
            entity.HasKey(e => new { e.IdTeacher, e.IdDiscipline, e.IdType })
                .HasName("Load_pk")
                .IsClustered(false);

            entity.ToTable("Load");

            entity.HasOne(d => d.IdDisciplineNavigation)
                .WithMany(p => p.Loads)
                .HasForeignKey(d => d.IdDiscipline)
                .HasConstraintName("Load_Discipline_Id_fk");

            entity.HasOne(d => d.IdTeacherNavigation)
                .WithMany(p => p.Loads)
                .HasForeignKey(d => d.IdTeacher)
                .HasConstraintName("Load_Teacher_Id_fk");

            entity.HasOne(d => d.IdTypeNavigation)
                .WithMany(p => p.Loads)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("Load_OccupationTypes_Id_fk");
        }
    }
}