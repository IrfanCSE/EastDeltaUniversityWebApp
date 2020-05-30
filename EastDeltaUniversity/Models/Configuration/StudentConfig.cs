using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.Configuration
{
    public class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.Registration)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            HasIndex(x => x.Email)
                .IsUnique();

            Property(x => x.Contact)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            HasIndex(x => x.Contact)
                .IsUnique();


            Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired();

            Property(x => x.Address)
                .HasMaxLength(250)
                .HasColumnType("varchar")
                .IsRequired();

            HasRequired(x=>x.Department)
                .WithMany(x=>x.Students)
                .HasForeignKey(x=>x.DepartmentId)
                .WillCascadeOnDelete(false);
        }
    }
}