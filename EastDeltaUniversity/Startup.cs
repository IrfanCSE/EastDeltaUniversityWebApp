using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EastDeltaUniversity.Startup))]
namespace EastDeltaUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
