using NUnit.Framework;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiTest.Managers;

namespace WebApiTest
{
    public class WebApiTest
    {
        private string _location="Minsk";
        private string _geodata = "53.90255,27.563101";
        private string _presentDay = DateTime.Now.ToString("yyyy-MM-dd");

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SearchLocationAndSelectMinTemp()
        {
            var searchLocation = await ApiManager.SearchLocation(_location);
            var weather = await ApiManager.GetWeather(searchLocation.First().WoeId);
            var asddas = weather.ConsolidatedWeather.Select(x => x.MinTemp);

            Assert.AreEqual(searchLocation.First().Title, _location);
        }
        [Test]
        public async Task CheckGeoData()
        {
            var searchLocation = await ApiManager.SearchLocation(_location);

            Assert.AreEqual(searchLocation.First().LattLlong, _geodata);
        }

        [Test]
        public async Task WeatherPresentDay()
        {
            var presentDay=_presentDay.Replace("-", "/");
            var searchLocation = await ApiManager.SearchLocation(_location);
            var weather = await ApiManager.GetWeatherPresentDay(searchLocation.First().WoeId, presentDay);

            Assert.AreEqual(weather.First().ApplicableDate, _presentDay);
        }
        [Test]
        public async Task WeatherRequiredDay()
        {
            var requiredDay = DateTime.Now.AddYears(-5).ToString("yyyy-MM-dd").Replace("-", "/");
            var searchLocation = await ApiManager.SearchLocation(_location);
            var weather12 = await ApiManager.GetWeatherPresentDay(searchLocation.First().WoeId, requiredDay);

            Assert.IsTrue(weather12.Select(x => x.WeatherStateName).Any());
        }
    }
}