using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileUploadTest.Startup))]
namespace FileUploadTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
