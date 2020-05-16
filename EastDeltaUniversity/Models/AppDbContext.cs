using Microsoft.AspNet.Identity.EntityFramework;

namespace EastDeltaUniversity.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("AppDbContext")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}