using RestSharp;
using WeatherServiceRest.Abstraction;
using WeatherServiceRest.Models;

namespace WeatherServiceRest
{
    public class WeatherServiceRestful
    {
        private string _apiKey;
        private string _apiUrl;
        private string _units;

        public WeatherServiceRestful(IWeatherServiceRestConfiguration config)
        {
            _apiKey = config.ApiKey;
            _apiUrl = config.ApiUrl;
            _units = config.Units.ToString();
        }

        public WeatherService CallWeatherService(string country, string city)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest("/data/2.5/weather", Method.GET);
            request.AddParameter("q", string.Format("{0}, {1}", city, country));
            request.AddParameter("units", _units);
            request.AddParameter("appid", _apiKey);

            IRestResponse<WeatherService> response = client.Execute<WeatherService>(request);

            return response.Data;
        }
    }
}