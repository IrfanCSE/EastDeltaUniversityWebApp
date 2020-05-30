using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            HasKey(x => x.Id);

            HasRequired(x=>x.Department)
                .WithMany(x=>x.Classes)
                .HasForeignKey(x=>x.DepartmentId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Course)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.CourseId)
                .WillCascadeOnDelete(false);
            
            HasRequired(x => x.Day)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.DayId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Room)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.RoomId)
                .WillCascadeOnDelete(false);

            Property(x => x.FromTime)
                .HasColumnType("time")
                .IsRequired();

            Property(x => x.ToTime)
                .HasColumnType("time")
                .IsRequired();

            Property(x => x.IsActive)
                .IsRequired();

        }
    }
}