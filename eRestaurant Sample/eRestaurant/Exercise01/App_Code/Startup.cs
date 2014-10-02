using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exercise01.Startup))]
namespace Exercise01
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
