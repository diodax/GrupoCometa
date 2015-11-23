using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrupoCometaBranch.Startup))]
namespace GrupoCometaBranch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
