namespace WeatherApplicationAPI.Models
{
    public class WeatherForecast
    {
        public Location location { get; set; }
        public Temperature temperature { get; set; }
        public int humidity { get; set; }
    }
}