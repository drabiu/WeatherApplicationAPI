using Xunit;
using NSubstitute;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherApplicationAPI.WeatherService;
using AutoMapper;
using RestSharp;
using WeatherApplicationAPI.Models;

namespace WeatherApplicationUnitTests
{
    public class WeatherServiceAdapterTests
    {
        [Fact]
        public void WeatherSerivceAdapterShouldCallWeatherService()
        {
            var config = Substitute.For<WeatherServiceConfiguration>();
            var restClient = Substitute.For<RestClient>();
            var weatherService = Substitute.For<WeatherServiceRestful.WeatherServiceRestful>(config, restClient);
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
            var config = Substitute.For<WeatherServiceConfiguration>();
            var restClient = Substitute.For<RestClient>();
            var weatherService = Substitute.For<WeatherServiceRestful.WeatherServiceRestful>(config, restClient);

            var mapper = Substitute.For<IMapper>();
            var forecast = new WeatherForecast();
            forecast.temperature = new Temperature();
            forecast.temperature.value = 16;
            forecast.humidity = 88;
            mapper.Map<WeatherForecast>(Arg.Any<WeatherForecast>()).Returns(forecast);

            IWeatherService serviceAdapter = new WeatherServiceAdapter(weatherService, mapper);

            string city = "city";
            string country = "country";

            var result = serviceAdapter.GetCurrentWeatherForecast(city, country);

            Assert.Equal(88, result.humidity);
            Assert.Equal(16, result.temperature.value);
        }
    }
}
