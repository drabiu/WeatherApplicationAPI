using WeatherServiceRestful.Enums;

namespace WeatherServiceRestful.Abstraction
{
    public interface IWeatherServiceRestConfiguration
    {
        string ApiKey { get; }
        string ApiUrl { get; }
        Units Units { get; }
    }
}
