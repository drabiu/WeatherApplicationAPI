using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WeatherApplicationAPI;

[assembly: OwinStartup(typeof(Startup))]
namespace WeatherApplicationAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);

            app.UseWebApi(configuration);
        }
    }
}