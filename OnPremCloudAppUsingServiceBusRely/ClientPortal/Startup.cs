using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientPortal.Startup))]
namespace ClientPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
