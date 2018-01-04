using AutoMapper;
using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRestful;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceAdapter : IWeatherService
    {
        private readonly WeatherServiceRest _weatherService;
        private readonly IMapper _mapper;

        public WeatherServiceAdapter(WeatherServiceRest weatherServiceRest, IMapper mapper)
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