using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YarnOver.WebMVC.Startup))]
namespace YarnOver.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
