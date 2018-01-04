using System.Configuration;
using WeatherServiceRestful.Abstraction;
using WeatherServiceRestful.Enums;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceConfiguration : IWeatherServiceRestConfiguration
    {
        public string ApiKey => ConfigurationManager.AppSettings.Get("WeatherApiKey");

        public string ApiUrl => "http://api.openweathermap.org";

        public Units Units => Units.Metric;
    }
}