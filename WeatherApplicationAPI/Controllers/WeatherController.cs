using System.Web.Http;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest.Abstraction;

namespace WeatherApplicationAPI.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherService _weatherService;

        public WeatherController(IWeatherService service)
        {
            _weatherService = service;
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
