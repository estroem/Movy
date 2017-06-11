using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movy.Startup))]
namespace Movy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
