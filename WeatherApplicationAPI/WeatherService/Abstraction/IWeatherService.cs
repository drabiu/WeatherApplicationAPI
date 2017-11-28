using WeatherApplicationAPI.Models;

namespace WeatherApplicationAPI.WeatherService.Abstraction
{
    public interface IWeatherService
    {
        WeatherForecast GetCurrentWeatherForecast(string city, string country);
    }
}
