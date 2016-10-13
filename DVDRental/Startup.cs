using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDRental.Startup))]
namespace DVDRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
