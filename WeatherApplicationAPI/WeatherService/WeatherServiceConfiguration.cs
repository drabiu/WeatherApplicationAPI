using System.Configuration;
using WeatherServiceRest.Abstraction;
using WeatherServiceRest.Enums;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceConfiguration : IWeatherServiceRestConfiguration
    {
        public string ApiKey => ConfigurationManager.AppSettings.Get("WeatherApiKey");

        public string ApiUrl => "http://api.openweathermap.org";

        public Units Units => Units.metric;
    }
}