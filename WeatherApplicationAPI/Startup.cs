using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WeatherApplicationAPI;
using WeatherApplicationAPI.App_Start;

[assembly: OwinStartup(typeof(Startup))]
namespace WeatherApplicationAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();

            // Web API configuration and services
            var builder = new ContainerBuilder();
            var container = ConfigureDI(builder);

            // Web API routes
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);
            app.UseWebApi(configuration);
        }

        public virtual IContainer ConfigureDI(ContainerBuilder builder)
        {
            DIContainerConfiguration containerConfig = new DIContainerConfiguration();

            return containerConfig.Create(builder);
        }
    }
}