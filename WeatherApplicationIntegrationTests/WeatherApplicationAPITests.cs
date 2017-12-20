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

            Assert.Equal("Gdynia", result.Location.City);
            Assert.Equal("PL", result.Location.Country);
            Assert.InRange<int>(result.Humidity, 0, 100);
            Assert.InRange<int>(result.Temperature.Value, -100, 100);
        }
    }
}
