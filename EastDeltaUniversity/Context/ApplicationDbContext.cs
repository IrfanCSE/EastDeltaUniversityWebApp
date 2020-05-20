using System.Data.Entity;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EastDeltaUniversity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfig());
            modelBuilder.Configurations.Add(new SemesterConfig());
            modelBuilder.Configurations.Add(new CourseConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}