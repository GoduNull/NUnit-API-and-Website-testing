using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTest.Models
{
    class WeatherResponseModel
    {
        [JsonProperty("title")]
        public string Location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public int WoeId { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("consolidated_weather")]
        public List<WeatherModel> ConsolidatedWeather { get; set; }
    }
}
