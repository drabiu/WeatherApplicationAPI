namespace WeatherApplicationAPI.WeatherService.Abstraction
{
    public interface IWeather
    {
       string GetCurrentWeatherForecast(string city, string country);
    }
}
