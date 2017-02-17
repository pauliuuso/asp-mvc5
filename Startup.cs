using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspnet.Startup))]
namespace aspnet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
