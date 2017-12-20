namespace WeatherApplicationAPI.Models
{
    public class Location
    {
        public string City { get; set; }

        public string Country { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Country);
        }
    }
}