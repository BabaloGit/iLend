using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iLend.Startup))]
namespace iLend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
