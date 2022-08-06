using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewAngular.Startup))]
namespace NewAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
