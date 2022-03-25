using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPizza.Startup))]
namespace WebPizza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
