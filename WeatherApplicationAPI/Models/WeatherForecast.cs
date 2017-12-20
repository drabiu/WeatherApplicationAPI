namespace WeatherApplicationAPI.Models
{
    public class WeatherForecast
    {
        public Location Location { get; set; }
        public Temperature Temperature { get; set; }
        public int Humidity { get; set; }
    }
}