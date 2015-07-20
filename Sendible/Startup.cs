using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sendible.Startup))]
namespace Sendible
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
