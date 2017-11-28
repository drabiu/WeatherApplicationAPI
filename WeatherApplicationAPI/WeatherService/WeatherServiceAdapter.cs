using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService.Abstraction;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceAdapter : IWeatherService
    {
        WeatherServiceRest _weatherService;

        public WeatherServiceAdapter(WeatherServiceRest weatherServiceRest)
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