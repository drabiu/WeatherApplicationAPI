using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceAdapter : IWeatherService
    {
        WeatherServiceRestful _weatherService;

        public WeatherServiceAdapter(WeatherServiceRestful weatherServiceRest)
        {
            _weatherService = weatherServiceRest;
        }

        public WeatherForecast GetCurrentWeatherForecast(string city, string country)
        {
            var result = _weatherService.CallWeatherService(country, city);

            return new WeatherForecast();
        }
    }
}