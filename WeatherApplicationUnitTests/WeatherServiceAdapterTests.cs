using Xunit;
using NSubstitute;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherApplicationAPI.WeatherService;
using AutoMapper;
using RestSharp;
using WeatherApplicationAPI.Models;
using WeatherServiceRestful;
using WeatherServiceRestful.Abstraction;

namespace WeatherApplicationUnitTests
{
    public class WeatherServiceAdapterTests
    {
        private readonly IWeatherServiceRestConfiguration _config;
        private readonly IRestClient _restClient;
        private readonly WeatherServiceRest _weatherService;
        private readonly IMapper _mapper;

        public WeatherServiceAdapterTests()
        {
            _config = Substitute.For<WeatherServiceConfiguration>();
            _restClient = Substitute.For<IRestClient>();
            _weatherService = Substitute.For<WeatherServiceRest>(_config, _restClient);
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void WeatherSerivceAdapterShouldCallWeatherService()
        {
            IWeatherService serviceAdapter = new WeatherServiceAdapter(_weatherService, _mapper);

            string city = "city";
            string country = "country";

            serviceAdapter.GetCurrentWeatherForecast(city, country);

            _weatherService.Received(1).CallWeatherService(Arg.Is<string>(city), Arg.Is<string>(country));
        }

        [Fact]
        public void WeatherSerivceAdapterShouldReturnWeather()
        {
            var forecast = new WeatherForecast();
            forecast.Temperature = new Temperature();
            forecast.Temperature.Value = 16;
            forecast.Humidity = 88;
            _mapper.Map<WeatherForecast>(Arg.Any<WeatherForecast>()).Returns(forecast);

            IWeatherService serviceAdapter = new WeatherServiceAdapter(_weatherService, _mapper);

            string city = "city";
            string country = "country";

            var result = serviceAdapter.GetCurrentWeatherForecast(city, country);

            Assert.Equal(88, result.Humidity);
            Assert.Equal(16, result.Temperature.Value);
        }
    }
}
