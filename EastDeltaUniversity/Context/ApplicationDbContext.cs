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

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}