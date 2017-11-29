using WeatherServiceRest.Enums;

namespace WeatherServiceRest.Abstraction
{
    public interface IWeatherServiceRestConfiguration
    {
        string ApiKey { get; }
        string ApiUrl { get; }
        Units Units { get; }
    }
}
