using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class StudentCourseConfig:EntityTypeConfiguration<StudentCourse>
    {
        public StudentCourseConfig()
        {
            HasKey(x => x.Id);

            HasRequired(x=>x.Student)
                .WithMany(x=>x.StudentCourses)
                .HasForeignKey(x=>x.StudentId)
                .WillCascadeOnDelete(false);

            HasRequired(x=>x.Course)
                .WithMany(x=>x.StudentCourses)
                .HasForeignKey(x=>x.CourseId)
                .WillCascadeOnDelete(false);

            Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired();

            Property(x => x.IsActive)
                .IsRequired();

            HasRequired(x=>x.Grade)
                .WithMany(x=>x.StudentCourses)
                .HasForeignKey(x=>x.GradeId)
                .WillCascadeOnDelete(false);
        }
    }
}