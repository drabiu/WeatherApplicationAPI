﻿using RestSharp;
using System;
using WeatherServiceRestful.Abstraction;
using WeatherServiceRestful.Models;

namespace WeatherServiceRestful
{
    public class WeatherServiceRest
    {
        private string _apiKey;
        private string _units;
        private string _apiUrl;

        private IRestClient _restClient;

        public WeatherServiceRest(IWeatherServiceRestConfiguration config, IRestClient restClient)
        {
            _apiKey = config.ApiKey;
            _units = config.Units.ToString();
            _apiUrl = config.ApiUrl;

            _restClient = restClient;
        }

        public WeatherService CallWeatherService(string country, string city)
        {
            _restClient.BaseUrl = new Uri(_apiUrl);

            var request = new RestRequest("/data/2.5/weather", Method.GET);
            request.AddParameter("q", string.Format("{0}, {1}", city, country));
            request.AddParameter("units", _units);
            request.AddParameter("appid", _apiKey);

            IRestResponse<WeatherService> response = _restClient.Execute<WeatherService>(request);

            return response.Data;
        }
    }
}