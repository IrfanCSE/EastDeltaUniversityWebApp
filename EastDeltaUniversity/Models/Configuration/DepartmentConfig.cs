using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class DepartmentConfig:EntityTypeConfiguration<Department>
    {
        public DepartmentConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Code)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}