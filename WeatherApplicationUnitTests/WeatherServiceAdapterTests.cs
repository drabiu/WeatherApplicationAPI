using Xunit;
using NSubstitute;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherApplicationAPI.WeatherService;
using AutoMapper;

namespace WeatherApplicationUnitTests
{
    public class WeatherServiceAdapterTests
    {
        [Fact]
        public void WeatherSerivceAdapterShouldCallWeatherService()
        {
            var weatherService = Substitute.For<WeatherServiceRestful.WeatherServiceRestful>();
            var mapper = Substitute.For<IMapper>();

            IWeatherService serviceAdapter = new WeatherServiceAdapter(weatherService, mapper);

            string city = "city";
            string country = "country";

            serviceAdapter.GetCurrentWeatherForecast(city, country);

            weatherService.Received(1).CallWeatherService(Arg.Is<string>(city), Arg.Is<string>(country));
        }

        [Fact]
        public void WeatherSerivceAdapterShouldReturnWeather()
        {
            var weatherService = Substitute.For<WeatherServiceRestful.WeatherServiceRestful>();
            var mapper = Substitute.For<IMapper>();

            IWeatherService serviceAdapter = new WeatherServiceAdapter(weatherService, mapper);

            //string city = "city";
            //string country = "country";

            //serviceAdapter.GetCurrentWeatherForecast(city, country);

            //weatherService.Received(1).CallWeatherService(Arg.Is<string>(city), Arg.Is<string>(country));
        }
    }
}
