using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HardwarePC.WebSite.Startup))]
namespace HardwarePC.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
