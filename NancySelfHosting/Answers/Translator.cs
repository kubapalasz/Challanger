using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class Translator : IAnswer
    {
        private string[] _parameters;

        public Translator(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<string[]>(parameters);
        }

        public string GetAnswer()
        {
            return new GoogleService().GetTranslation(_parameters);
        }
    }
}

/*
         using (
               var client =
                   new HttpClient(new HttpClientHandler { Credentials = new NetworkCredential(account.ApiKey, account.ApiPassword) }))
           {
               client.BaseAddress = new Uri(account.Site);
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               var chargeRequest = new ChargeRequestMessage
               {
                   ChargeRequest = new ChargeRequest
                   {
                       Memo = memo,
                       Amount = amount,
                       DelayCapture = delayCapture
                   }
               };

               var json = JsonConvert.SerializeObject(chargeRequest);
               var msg = new StringContent(json);
               msg.Headers.ContentType = new MediaTypeHeaderValue("application/json");

               var response =
                   client.PostAsync(string.Format("subscriptions/{0}/charges.json", subscriptionId), msg).Result;

               var responseInJson = response.Content.ReadAsStringAsync().Result;
               var allocationResult = JsonConvert.DeserializeObject<ChargeResponseMessage>(responseInJson);
               if (allocationResult.Errors != null && allocationResult.Errors.Count > 0)
               {
                   throw new InvalidOperationException(
                       string.Format("Failed to charge {0} with memo {1} in chargify - response = {2}", amount, memo,
                                     responseInJson));
               }
           }*/