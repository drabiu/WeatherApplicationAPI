using AutoMapper;
using System.Web.Http;
using WeatherApplicationAPI.WeatherService.Abstraction;

namespace WeatherApplicationAPI.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherService _weatherService;
        private IMapper _mapper;

        public WeatherController(IWeatherService service, IMapper mapper)
        {
            _weatherService = service;
            _mapper = mapper;
        }

        [Route("api/weather/{country}/{city}")]
        [HttpGet]
        public IHttpActionResult GetWeather(string country, string city)
        {
            var result = _weatherService.GetCurrentWeatherForecast(country, city);

            return Ok();
        }
    }
}
