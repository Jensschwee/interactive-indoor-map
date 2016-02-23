using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Indoor_Mapping.Startup))]
namespace Indoor_Mapping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
