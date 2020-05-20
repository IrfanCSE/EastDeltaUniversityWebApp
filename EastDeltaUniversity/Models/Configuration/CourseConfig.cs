using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class CourseConfig:EntityTypeConfiguration<Course>
    {
        public CourseConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Code)
                .HasMaxLength(10)
                .HasColumnType("varchar")
                .IsRequired();
            
            HasIndex(x => x.Code)
                .IsUnique();

            Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            HasIndex(x => x.Name)
                .IsUnique();

            Property(x => x.Code)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            HasRequired(x => x.Department)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.DepartmentId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Semester)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.SemesterId)
                .WillCascadeOnDelete(false);
        }
    }
}