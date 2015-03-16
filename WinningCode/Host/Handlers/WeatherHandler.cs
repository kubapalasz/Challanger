using System;
using System.Net;
using GeekUp.Host.Models;
using Newtonsoft.Json;

namespace GeekUp.Host.Handlers
{
    // http://openweathermap.org/api
    public sealed class WeatherHandler : IQueryHandler
    {
        private const string WeatherUrlTemplate = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric";
        private const string ForecastUrlTemplate = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric";

        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::ForecastQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var location = question.Parameters[0];

            var current = GetCurrentTemperature(location);
            //var today = GetTemperatureInNDays(location, 0);
            //var tomorrow = GetTemperatureInNDays(location, 1);
            //var dayAfterTomorrow = GetTemperatureInNDays(location, 2);

            return current;
        }

        private static string GetCurrentTemperature(string location)
        {
            var url = string.Format(WeatherUrlTemplate, location);
            var str = (new WebClient()).DownloadString(url);

            dynamic data = JsonConvert.DeserializeObject(str);
            var temperature = data["main"]["temp"];

            return Math.Round(Double.Parse(temperature)).ToString();
        }

        private static string GetTemperatureInNDays(string location, int days)
        {
            var url = string.Format(ForecastUrlTemplate, location);
            var str = (new WebClient()).DownloadString(url);

            dynamic json = JsonConvert.DeserializeObject(str);
            var temperature = json["list"][days]["temp"]["day"];

            return Math.Round(Double.Parse(temperature)).ToString();
        }
    }
}
