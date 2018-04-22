using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LookTechnoCMS.Web.Startup))]
namespace LookTechnoCMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
