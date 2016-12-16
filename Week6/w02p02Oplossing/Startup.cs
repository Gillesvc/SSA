using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(w02p02Oplossing.Startup))]
namespace w02p02Oplossing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
