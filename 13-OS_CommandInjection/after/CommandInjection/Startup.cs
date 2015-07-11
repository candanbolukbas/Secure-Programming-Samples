using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommandInjection.Startup))]
namespace CommandInjection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
