using WeatherApplicationAPI.WeatherService.Abstraction;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceAdapter : IWeather
    {
        WeatherServiceRest _weatherService;

        public WeatherServiceAdapter(WeatherServiceRest weatherServiceRest)
        {
            _weatherService = weatherServiceRest;
        }

        public string GetCurrentWeatherForecast(string city, string country)
        {
            throw new System.NotImplementedException();
        }
    }
}