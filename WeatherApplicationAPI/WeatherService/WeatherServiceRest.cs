using RestSharp;
using System.Configuration;

namespace WeatherApplicationAPI.WeatherService
{
    public class WeatherServiceRest
    {
        private string _apiKey;
        private const string _apiUrl = "http://api.openweathermap.org";

        public WeatherServiceRest()
        {
            _apiKey = ConfigurationManager.AppSettings.Get("WeatherApiKey");
        }

        public string CallWeatherService(string country, string city)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest("/data/2.5/weather", Method.GET);
            request.AddParameter("q", string.Format("{0}, {1}", city, country));
            request.AddParameter("appid", _apiKey);

            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}