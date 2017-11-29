using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest;
using WeatherServiceRest.Abstraction;

namespace WeatherApplicationAPI.App_Start
{
    public class DIContainer
    {
        public IContainer Create()
        {
            var builder = new ContainerBuilder();
      
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WeatherServiceConfiguration>().As<IWeatherServiceRestConfiguration>();
            builder.RegisterType<WeatherServiceAdapter>().As<IWeatherService>();
            builder.RegisterType<WeatherServiceRestful>().AsSelf();

            return builder.Build();
        }
    }
}