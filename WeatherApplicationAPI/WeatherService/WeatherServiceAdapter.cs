using AutoMapper;
using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService.Abstraction;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceAdapter : IWeatherService
    {
        WeatherServiceRestful.WeatherServiceRestful _weatherService;
        IMapper _mapper;

        public WeatherServiceAdapter(WeatherServiceRestful.WeatherServiceRestful weatherServiceRest, IMapper mapper)
        {
            _weatherService = weatherServiceRest;
            _mapper = mapper;
        }

        public WeatherForecast GetCurrentWeatherForecast(string city, string country)
        {
            var result = _weatherService.CallWeatherService(country, city);
            var weather = _mapper.Map<WeatherForecast>(result);

            return weather;
        }
    }
}