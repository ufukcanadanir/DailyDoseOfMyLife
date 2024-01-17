
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyDoseOfMyLife.Model
{
    internal class WeatherAPI
    {
        private string weatherApiKey = "573951b7b1eb092be33e4c7699fed4d1";
        private string? latitude;
        private string? longtitude;
        private int tempInt;
        private string? temperature;
        public async Task<Dictionary<string, string>> GetWeather()
        {

            // To find latitude and longtitude
            // to get location setting -> location permission is needed on Windows
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();
            if (location != null)
            {
                latitude = location.Latitude.ToString();
                longtitude = location.Longitude.ToString();
            }
                Dictionary<string, string> weatherInfo = new Dictionary<string, string>();
                string connection = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longtitude}&mode=xml&appid={weatherApiKey}&units=metric";
                XDocument weather = XDocument.Load(connection);
                if(int.TryParse(weather.Descendants("temperature").ElementAt(0).Attribute("value").Value, out tempInt))
            {
                temperature = tempInt.ToString("0");
            }
            else
            {
                temperature = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            }
                string weatherstate = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
                weatherInfo.Add("Temperature", temperature);
                weatherInfo.Add("WeatherState", weatherstate);
            return weatherInfo;
        }
        
    }
}
