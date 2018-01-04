using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApplicationAPI.Models;
using WeatherApplicationAPI.WeatherService.Abstraction;

namespace WeatherApplicationAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService service)
        {
            _weatherService = service;
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
