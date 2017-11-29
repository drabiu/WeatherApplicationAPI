using System.Web.Http;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest.Abstraction;

namespace WeatherApplicationAPI.Controllers
{
    public class WeatherController : ApiController
    {
        public WeatherController(IWeatherService service)
        {
        }

        [Route("api/weather/{country}/{city}")]
        [HttpGet]
        public IHttpActionResult GetWeather(string country, string city)
        {
            return Ok();
        }
    }
}
