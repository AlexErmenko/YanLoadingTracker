﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace YanLoadingTracker.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            Loads = new HashSet<Load>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual ICollection<Load> Loads { get; set; }
    }
}