﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YanLoadingTracker.Models
{
    public partial class Department
    {
        public Department()
        {
            Teachers = new HashSet<Teacher>();
        }

        [Display(Name = "Код")]
        public int Id { get; set; }

        [Display(Name= "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Номер")]
        [Required]
        public int Number { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }


        public override string ToString() => $"{Name} #{Number}";
    }
}
