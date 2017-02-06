using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab05.Startup))]
namespace Lab05
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
