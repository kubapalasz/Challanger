using System;
using System.Globalization;
using System.Net;
using GeekUp.Host.Models;
using Newtonsoft.Json;

namespace GeekUp.Host.Handlers
{
    public sealed class CurrencyHandler : IQueryHandler
    {
        private const string UrlTemplate = "http://rate-exchange.appspot.com/currency?from={0}&to={1}";

        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::ExchangeRateQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var value = Convert.ToDouble(question.Parameters[0]);
            var from = question.Parameters[1];
            var to = question.Parameters[3];

            var rate = GetConversionRate(from, to);
            var converted = Math.Round(value * rate, 2);

            return converted.ToString(CultureInfo.InvariantCulture);
        }

        private static double GetConversionRate(string from, string to)
        {
            var url = string.Format(UrlTemplate, from, to);
            var str = (new WebClient()).DownloadString(url);

            dynamic data = JsonConvert.DeserializeObject(str);
            var rate = data["rate"];

            return Convert.ToDouble(rate);
        }
    }
}
