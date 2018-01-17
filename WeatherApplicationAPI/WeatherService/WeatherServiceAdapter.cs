using AutoMapper;
using System.Threading.Tasks;
using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRestful;
using WeatherServiceRestful.Abstraction;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceAdapter : IWeatherService
    {
        private readonly IWeatherServiceRest _weatherService;
        private readonly IMapper _mapper;

        public WeatherServiceAdapter(IWeatherServiceRest weatherServiceRest, IMapper mapper)
        {
            _weatherService = weatherServiceRest;
            _mapper = mapper;
        }

        public async Task<WeatherForecast> GetCurrentWeatherForecast(string city, string country)
        {
            var result = await _weatherService.CallWeatherServiceAsync(country, city);
            var weather = _mapper.Map<WeatherForecast>(result);

            return weather;
        }
    }
}