namespace WeatherApplicationAPI.Models
{
    public class WeatherForecast
    {
        public Temperature Temperature { get; set; }

        public Location Location { get; set; }

        public string Humidity { get; set; }
    }
}