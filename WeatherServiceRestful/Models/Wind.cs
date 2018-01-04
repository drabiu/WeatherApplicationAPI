﻿using Newtonsoft.Json;

namespace WeatherServiceRestful.Models
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Deg { get; set; }
    }
}
