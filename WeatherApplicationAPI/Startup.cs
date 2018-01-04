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

            //ConfigureRoutes(configuration);

            //ConfigureDependencyResolver(configuration, app);

            //ConfigureJsonSerialization(configuration);
            //configuration.Filters.Add(new GlobalExceptionFilter());
            //configuration.MessageHandlers.Add(new MessageLoggingHandler());

            app.UseWebApi(configuration);
        }
    }
}