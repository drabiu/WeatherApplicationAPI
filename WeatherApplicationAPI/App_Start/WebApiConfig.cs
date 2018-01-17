using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using WeatherApplicationAPI.App_Start;
using WeatherApplicationAPI.Logging;

namespace WeatherApplicationAPI
{
    public static class WebApiConfig
    {
        private static IContainer _container;

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var builder = new ContainerBuilder();
            DIContainerConfiguration containerConfiguration = new DIContainerConfiguration();
            _container = containerConfiguration.Create(builder);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new GlobalExceptionFilter());
            config.MessageHandlers.Add(new MessageLoggingHandler());
            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }
    }
}
