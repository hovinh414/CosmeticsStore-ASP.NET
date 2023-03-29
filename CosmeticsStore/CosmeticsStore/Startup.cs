using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CosmeticsStore.Startup))]
namespace CosmeticsStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
