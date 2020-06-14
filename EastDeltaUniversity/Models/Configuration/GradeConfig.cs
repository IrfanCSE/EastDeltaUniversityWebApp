using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class GradeConfig:EntityTypeConfiguration<Grade>
    {
        public GradeConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Letter)
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .IsRequired();

            Property(x => x.Point)
                .IsRequired();
        }
    }
}