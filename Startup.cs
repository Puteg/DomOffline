using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DomOffline.Startup))]
namespace DomOffline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
