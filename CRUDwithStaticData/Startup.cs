using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDwithStaticData.Startup))]
namespace CRUDwithStaticData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
