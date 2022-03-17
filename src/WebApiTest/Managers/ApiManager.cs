using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Managers
{
    internal class ApiManager
    {
        private static HttpClient _httpClient = new HttpClient();
        public static async Task<List<WeatherSearchModel>> SearchLocation(string location)
        {
            var result = await _httpClient.GetAsync($"https://www.metaweather.com/api/api/location/search/?query={location}");
            return JsonConvert.DeserializeObject<List<WeatherSearchModel>>(
               await result.Content.ReadAsStringAsync());
        }
        public static async Task<WeatherResponseModel> GetWeather(int id)
        {
            var result = await _httpClient.GetAsync($"https://www.metaweather.com//api/location/{id}/");
            return JsonConvert.DeserializeObject<WeatherResponseModel>(
               await result.Content.ReadAsStringAsync());
        }
        public static async Task<List<WeatherModel>> GetWeatherPresentDay(int id, string date)
        {
            var result = await _httpClient.GetAsync($"https://www.metaweather.com/api/location/{id}/{date}");
            return JsonConvert.DeserializeObject<List<WeatherModel>>(
               await result.Content.ReadAsStringAsync());
        }
    }
}
