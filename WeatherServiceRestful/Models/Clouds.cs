using Newtonsoft.Json;

namespace WeatherServiceRestful.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
