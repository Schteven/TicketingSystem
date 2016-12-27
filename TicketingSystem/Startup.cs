using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketingSystem.Startup))]
namespace TicketingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
