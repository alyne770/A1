using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LivroDigital.Startup))]
namespace LivroDigital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
