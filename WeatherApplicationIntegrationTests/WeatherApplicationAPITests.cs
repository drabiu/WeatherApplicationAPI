using Autofac;
using AutoMapper;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NSubstitute;
using WeatherApplicationAPI;
using WeatherApplicationAPI.App_Start;
using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherApplicationIntegrationTests.Stubs;
using WeatherServiceRestful.Abstraction;
using WeatherServiceRestful.Models;
using Xunit;

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
            //using (var server = TestServer.Create<TestStartup>())
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

        [Fact]
        public void WeatherAdapterShouldReturnWeatherForGivenCity2()
        {
            DIContainerConfiguration container = new DIContainerConfiguration();
            var builder = new ContainerBuilder();
            var autofac = container.Create(builder);
            //var config = Substitute.For<IWeatherServiceRestConfiguration>();
            //config.ApiUrl.Returns("http://url");
            //config.Units.Returns(Units.Metric);
            //config.ApiKey.Returns("aaa");

            //var restClient = Substitute.For<IRestClient>();
            //var weatherService = Substitute.For<IWeatherServiceRest>(config, restClient);
            var weatherService = Substitute.For<IWeatherServiceRest>();

            //weatherService.CallWeatherService(Arg.Any<string>(), Arg.Any<string>()).Returns(x =>
            //{
            //    return new WeatherService()
            //    {
            //        Main = new Main() { Humidity = 10, Temp = 10 },
            //        Name = (string)x[1],
            //        Sys = new Sys() { Country = (string)x[0] }
            //    };
            //});

            weatherService.CallWeatherServiceAsync(Arg.Any<string>(), Arg.Any<string>()).Returns(x =>
            {
                return new WeatherService()
                {
                    Main = new Main() { Humidity = 10, Temp = 10 },
                    Name = (string)x[1],
                    Sys = new Sys() { Country = (string)x[0] }
                };
            });

            IWeatherService _weatherService = new WeatherServiceAdapter(weatherService, autofac.Resolve<IMapper>());
            var result = _weatherService.GetCurrentWeatherForecast("Gdynia", "Poland");
        }
    }
}
