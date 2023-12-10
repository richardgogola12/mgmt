using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mgmt.Startup))]
namespace mgmt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
