using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(module1.Startup))]
namespace module1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
