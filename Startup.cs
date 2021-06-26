using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Baitap.Startup))]
namespace Baitap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
