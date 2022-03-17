using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTest.Models
{
    internal class WeatherSearchModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public int WoeId { get; set; }

        [JsonProperty("latt_long")]
        public string LattLlong { get; set; }

    }
}
