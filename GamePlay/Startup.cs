using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamePlay.Startup))]
namespace GamePlay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
