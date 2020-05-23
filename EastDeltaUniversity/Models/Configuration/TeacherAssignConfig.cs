using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class TeacherAssignConfig:EntityTypeConfiguration<TeacherAssign>
    {
        public TeacherAssignConfig()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Teacher)
                .WithMany(x => x.TeacherAssigns)
                .HasForeignKey(x => x.TeacherId)
                .WillCascadeOnDelete(false);

            HasRequired(x=>x.Course)
                .WithMany(x=>x.TeacherAssigns)
                .HasForeignKey(x=>x.CourseId)
                .WillCascadeOnDelete(false);

            HasRequired(x=>x.Department)
                .WithMany(x=>x.TeacherAssigns)
                .HasForeignKey(x=>x.DepartmentId)
                .WillCascadeOnDelete(false);
        }
    }
}