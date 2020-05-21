using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EastDeltaUniversity.Models.Configuration
{
    public class TeacherConfig : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Address)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            HasIndex(x => x.Email)
                .IsUnique();

            Property(x => x.ContactNo)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            HasIndex(x => x.ContactNo)
                .IsUnique();

            HasRequired(x=>x.Designation)
                .WithMany(x=>x.Teachers)
                .HasForeignKey(x=>x.DesignationId)
                .WillCascadeOnDelete(false);

            HasRequired(x=>x.Department)
                .WithMany(x=>x.Teachers)
                .HasForeignKey(x=>x.DepartmentId)
                .WillCascadeOnDelete(false);

        }
    }
}