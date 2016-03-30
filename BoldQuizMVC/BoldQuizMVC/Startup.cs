using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoldQuizMVC.Startup))]
namespace BoldQuizMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
