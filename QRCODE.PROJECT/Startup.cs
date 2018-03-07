using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QRCODE.PROJECT.Startup))]
namespace QRCODE.PROJECT
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
