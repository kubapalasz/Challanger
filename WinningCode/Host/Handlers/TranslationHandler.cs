using System;
using System.Linq;
using System.Net;
using GeekUp.Host.Models;
using Microsoft;
using Newtonsoft.Json;

namespace GeekUp.Host.Handlers
{
    public sealed class TranslationHandler : IQueryHandler
    {
        private const string BingApiKey = "YOUR KEY HERE";
        private const string BingApiUrl = "https://api.datamarket.azure.com/Bing/MicrosoftTranslator/";

        private const string GoogleApiKey = "YOUR KEY HERE";
        private const string GoogleApiUrl = "https://www.googleapis.com/language/translate/v2?key={0}&source={1}&target={2}&q={3}";

        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::TranslationQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var text = question.Parameters[0];
            const string fromLanguage = "en";
            var toLanguage = question.Parameters[1];

            return GoogleTranslateText(text, fromLanguage, toLanguage);
        }

        public string GoogleTranslateText(string input, string fromLanguage, string toLanguage)
        {
            var url = string.Format(GoogleApiUrl, GoogleApiKey, fromLanguage, toLanguage, input);
            var json = (new WebClient()).DownloadString(url);

            dynamic results = JsonConvert.DeserializeObject(json);
            return results["data"]["translations"][0]["translatedText"].ToString();
        }

        public string BingTranslateText(string input, string fromLanguage, string toLanguage)
        {
            var translator = new TranslatorContainer(new Uri(BingApiUrl))
            {
                Credentials = new NetworkCredential(BingApiKey, BingApiKey)
            };

            var results = translator.Translate(input, toLanguage, fromLanguage).Execute();

            if (results == null)
                return null;

            var translations = results.ToList();
            if (translations.Any() == false)
                return null;

            return translations.First().Text;
        }
    }
}
