using WeatherApplicationAPI.App_Start;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using Autofac;
using Xunit;
using AutoMapper;
using WeatherServiceRestful;

namespace WeatherApplicationIntegrationTests
{
    public class WeatherApplicationAPITests
    {
        [Fact]
        public void WeatherAdapterShouldReturnWeatherForGivenCity()
        {
            DIContainer container = new DIContainer();
            var autofac = container.Create();
            var weatherServiceRest = autofac.Resolve<WeatherServiceRest>();
            var mapper = autofac.Resolve<IMapper>();

            IWeatherService _weatherService = new WeatherServiceAdapter(weatherServiceRest, mapper);

            var result = _weatherService.GetCurrentWeatherForecast("Gdynia", "Poland");

            //Assert.InRange<int>(_weatherAppResultPage.Humidity(), 0, 100);
            //Assert.InRange<double>(_weatherAppResultPage.Temperature(), -100, 100);
        }
    }
}
