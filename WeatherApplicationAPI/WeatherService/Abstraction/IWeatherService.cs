using System.Threading.Tasks;
using WeatherApplicationAPI.Models;

namespace WeatherApplicationAPI.WeatherService.Abstraction
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetCurrentWeatherForecast(string city, string country);
    }
}
