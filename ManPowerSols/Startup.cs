using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManPowerSols.Startup))]
namespace ManPowerSols
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
