using WeatherApplicationAPI.App_Start;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using Autofac;
using Xunit;
using AutoMapper;
using WeatherServiceRestful;
using Microsoft.Owin.Testing;
using WeatherApplicationAPI;
using Newtonsoft.Json;
using WeatherApplicationAPI.Models;

namespace WeatherApplicationIntegrationTests
{
    public class WeatherApplicationAPITests
    {
        [Theory]
        [InlineData("Poland", "Warsaw")]
        [InlineData("Germany", "Berlin")]
        [InlineData("Russia", "Moscow")]
        public async void WeatherAdapterShouldReturnWeatherForGivenCity(string country, string city)
        {
            using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync($"api/weather/{country}/{city}");
                string responseContent = await result.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<WeatherForecast>(responseContent);

                Assert.Equal(city, responseModel.Location.City);
                Assert.InRange<int>(responseModel.Humidity, 0, 100);
                Assert.InRange<int>(responseModel.Temperature.Value, -90, 60);
            }
        }
    }
}
