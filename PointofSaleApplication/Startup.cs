using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointofSaleApplication.Startup))]
namespace PointofSaleApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
