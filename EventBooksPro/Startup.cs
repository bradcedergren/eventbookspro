using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventBooksPro.Startup))]
namespace EventBooksPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
