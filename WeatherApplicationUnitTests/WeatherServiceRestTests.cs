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
        private readonly IRestClient _restClient;
        private readonly IWeatherServiceRestConfiguration _serviceConfiguration;

        public WeatherServiceRestTests()
        {
            _restClient = Substitute.For<IRestClient>();
            _serviceConfiguration = Substitute.For<IWeatherServiceRestConfiguration>();
            _serviceConfiguration.ApiUrl.Returns("http://url");
        }

        [Fact]
        public async System.Threading.Tasks.Task CallWeatherServiceShouldCallRestClientExecuteWithCityAndCountryParameterAsync()
        {
            var weatherService = new WeatherServiceRest(_serviceConfiguration, _restClient);

            await weatherService.CallWeatherServiceAsync("country", "city");

            await _restClient.Received(1).ExecuteTaskAsync<WeatherService>(Arg.Is<RestRequest>(a => a.Parameters.Any(p => p.Name == "q" && (string)p.Value == "city, country")));
        }

        [Fact]
        public async System.Threading.Tasks.Task CallWeatherServiceShouldCallRestClientExecuteWithUnitsParameterAsync()
        {
            _serviceConfiguration.Units.Returns(Units.Metric);

            var weatherService = new WeatherServiceRest(_serviceConfiguration, _restClient);

            await weatherService.CallWeatherServiceAsync("country", "city");

            await _restClient.Received(1).ExecuteTaskAsync<WeatherService>(Arg.Is<RestRequest>(a => a.Parameters.Any(p => p.Name == "units" && (string)p.Value == "Metric")));
        }

        [Fact]
        public async System.Threading.Tasks.Task CallWeatherServiceShouldCallRestClientExecuteWithApiKeyParameterAsync()
        {
            _serviceConfiguration.ApiKey.Returns("key");

            var weatherService = new WeatherServiceRest(_serviceConfiguration, _restClient);

            await weatherService.CallWeatherServiceAsync("country", "city");

            await _restClient.Received(1).ExecuteTaskAsync<WeatherService>(Arg.Is<RestRequest>(a => a.Parameters.Any(p => p.Name == "appid" && (string)p.Value == "key")));
        }
    }
}
