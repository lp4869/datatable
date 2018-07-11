using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEST_PAGING.Startup))]
namespace TEST_PAGING
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
