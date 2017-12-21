using AutoMapper;
using System.Web.Http;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherApplicationAPI.Models;
using System.Web.Http.Cors;

namespace WeatherApplicationAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private IWeatherService _weatherService;
        private IMapper _mapper;

        public WeatherController(IWeatherService service, IMapper mapper)
        {
            _weatherService = service;
            _mapper = mapper;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/weather/{country}/{city}")]
        [HttpGet]
        public IHttpActionResult GetWeather(string country, string city)
        {
            WeatherForecast result = _weatherService.GetCurrentWeatherForecast(city, country);
            if (result == null || !result.Location.IsValid())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
