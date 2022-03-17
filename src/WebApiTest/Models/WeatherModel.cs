using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTest.Models
{
    class WeatherModel
    {
        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonProperty("weather_state_abbr")]
        public string WeatherAbbr { get; set; }

        [JsonProperty("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("applicable_date")]
        public string ApplicableDate { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }

        [JsonProperty("predictability")]
        public int Predictability { get; set; }
    }
}
