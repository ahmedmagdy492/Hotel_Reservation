using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotels_Resrevation.Startup))]
namespace Hotels_Resrevation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
