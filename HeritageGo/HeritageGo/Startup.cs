using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeritageGo.Startup))]
namespace HeritageGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
