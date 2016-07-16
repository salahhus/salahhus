using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleApplicationMVC.Startup))]
namespace SimpleApplicationMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
