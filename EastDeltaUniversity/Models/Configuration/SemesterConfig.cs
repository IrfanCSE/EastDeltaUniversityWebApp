﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class SemesterConfig:EntityTypeConfiguration<Semester>
    {
        public SemesterConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}