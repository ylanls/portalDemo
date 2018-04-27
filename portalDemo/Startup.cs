using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(portalDemo.Startup))]
namespace portalDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
