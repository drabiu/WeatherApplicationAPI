using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using WeatherApplicationAPI.App_Start;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest;

namespace WeatherApplicationAPI
{
    public static class WebApiConfig
    {
        private static IContainer _container;

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            DIContainer container = new DIContainer();
            _container = container.Create();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);

            //IWeatherService weather =  new WeatherServiceAdapter(new WeatherServiceRestful(new WeatherServiceConfiguration()));
            //weather.GetCurrentWeatherForecast("Gdynia", "Poland");
        }
    }
}
