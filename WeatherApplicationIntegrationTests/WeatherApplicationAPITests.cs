using WeatherApplicationAPI.App_Start;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using Autofac;
using Xunit;
using AutoMapper;

namespace WeatherApplicationIntegrationTests
{
    public class WeatherApplicationAPITests
    {
        [Fact]
        public void WeatherAdapterShouldReturnWeatherForGivenCity()
        {
            DIContainer container = new DIContainer();
            var autofac = container.Create();

            IWeatherService _weatherService = new WeatherServiceAdapter(autofac.Resolve< WeatherServiceRestful.WeatherServiceRestful>(), autofac.Resolve<IMapper>());
            var result = _weatherService.GetCurrentWeatherForecast("Gdynia", "Poland");
        }
    }
}
