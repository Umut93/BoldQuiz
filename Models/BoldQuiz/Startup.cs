using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoldQuiz.Startup))]
namespace BoldQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
