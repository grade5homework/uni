using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Martsinovsky1.Startup))]
namespace Martsinovsky1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
