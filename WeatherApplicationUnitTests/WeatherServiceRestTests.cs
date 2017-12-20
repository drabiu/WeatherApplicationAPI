using Xunit;
using NSubstitute;
using RestSharp;
using WeatherServiceRestful.Abstraction;
using WeatherServiceRestful.Models;
using System.Linq;
using WeatherServiceRestful.Enums;
using WeatherServiceRestful;

namespace WeatherApplicationUnitTests
{
    public class WeatherServiceRestTests
    {
        public WeatherServiceRestTests()
        {
            var restClient = Substitute.For<IRestClient>();
            var serviceConfiguration = Substitute.For<IWeatherServiceRestConfiguration>();
            serviceConfiguration.ApiUrl.Returns("http://url");
        }

        [Fact]
        public void CallWeatherServiceShouldCallRestClientExecuteWithCityAndCountryParameter()
        {
            var restClient = Substitute.For<IRestClient>();
            var serviceConfiguration = Substitute.For<IWeatherServiceRestConfiguration>();
            serviceConfiguration.ApiUrl.Returns("http://url");

            var weatherService = new WeatherServiceRest(serviceConfiguration, restClient);

            weatherService.CallWeatherService("country", "city");

            restClient.Received(1).Execute<WeatherService>(Arg.Is<RestRequest>(a => a.Parameters.Any(p => p.Name == "q" && (string)p.Value == "city, country")));
        }

        [Fact]
        public void CallWeatherServiceShouldCallRestClientExecuteWithUnitsParameter()
        {
            var restClient = Substitute.For<IRestClient>();
            var serviceConfiguration = Substitute.For<IWeatherServiceRestConfiguration>();
            serviceConfiguration.ApiUrl.Returns("http://url");
            serviceConfiguration.Units.Returns(Units.metric);

            var weatherService = new WeatherServiceRest(serviceConfiguration, restClient);

            weatherService.CallWeatherService("country", "city");

            restClient.Received(1).Execute<WeatherService>(Arg.Is<RestRequest>(a => a.Parameters.Any(p => p.Name == "units" && (string)p.Value == "metric")));
        }

        [Fact]
        public void CallWeatherServiceShouldCallRestClientExecuteWithApiKeyParameter()
        {
            var restClient = Substitute.For<IRestClient>();
            var serviceConfiguration = Substitute.For<IWeatherServiceRestConfiguration>();
            serviceConfiguration.ApiUrl.Returns("http://url");
            serviceConfiguration.ApiKey.Returns("key");

            var weatherService = new WeatherServiceRest(serviceConfiguration, restClient);

            weatherService.CallWeatherService("country", "city");

            restClient.Received(1).Execute<WeatherService>(Arg.Is<RestRequest>(a => a.Parameters.Any(p => p.Name == "appid" && (string)p.Value == "key")));
        }
    }
}
