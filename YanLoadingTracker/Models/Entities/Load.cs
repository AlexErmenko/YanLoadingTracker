﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YanLoadingTracker.Models
{
    public partial class Load
    {
        [Display(Name ="Преподаватель")]
        public int IdTeacher { get; set; }
        [Display(Name ="Дисциплина")]
        public int IdDiscipline { get; set; }
        [Display(Name ="Тип занятия")]
        public int IdType { get; set; }

        [Display(Name="Дисциплина")]
        public virtual Discipline IdDisciplineNavigation { get; set; }
        [Display(Name ="Преподаватель")]
        public virtual Teacher IdTeacherNavigation { get; set; }
        [Display(Name ="Тип занятия")]
        public virtual OccupationType IdTypeNavigation { get; set; }
    }
}
