using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting
{
    public class GoogleService
    {
        public string GetTranslation(string[] parameters)
        {

            var url =
                "https://www.googleapis.com/language/translate/v2?key=AIzaSyAFPQLxtnpikA8dGPaUsKzEKVYpHQOY6-I&source=en&target=" + parameters[1] +
                "&q="
            + parameters[0];
            using (var client = new HttpClient())
            {
                var response =
                    client.GetAsync(new Uri(url)).Result;

                var responseInJson = response.Content.ReadAsStringAsync().Result;
                var allocationResult = JsonConvert.DeserializeObject<TranslationResponse>(responseInJson);
                return allocationResult.Data.Translatios.FirstOrDefault().TranslatedText;
            }

        }

        public class TranslationResponse
        {
            [JsonProperty("data")]
            public Translations Data { get; set; }
        }

        public class Translations
        {
            [JsonProperty("translations")]
            public List<Translation> Translatios { get; set; }
        }

        public class Translation
        {
            [JsonProperty("translatedText")]
            public string TranslatedText { get; set; }
        }

    }
}