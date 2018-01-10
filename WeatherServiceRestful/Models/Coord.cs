﻿using Newtonsoft.Json;

namespace WeatherServiceRestful.Models
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}