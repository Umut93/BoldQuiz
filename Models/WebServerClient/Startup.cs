using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebServerClient.Startup))]
namespace WebServerClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
