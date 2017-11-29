using Autofac;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest.Abstraction;

namespace WeatherApplicationAPI.App_Start
{
    public class DIContainer
    {
        public IContainer Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WeatherServiceConfiguration>().As<IWeatherServiceRestConfiguration>();
            builder.RegisterType<WeatherServiceAdapter>().As<IWeatherService>();

            return builder.Build();
        }
    }
}