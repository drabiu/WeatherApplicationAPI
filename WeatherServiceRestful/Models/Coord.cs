using Newtonsoft.Json;

namespace WeatherServiceRestful.Models
{
    public class Coord
    {
        [JsonProperty("city")]
        public double Lon { get; set; }
        [JsonProperty("city")]
        public double Lat { get; set; }
    }
}