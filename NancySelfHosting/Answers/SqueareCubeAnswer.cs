using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class SqueareQubeAnswer
    {
        private int[] _parameters;

        public SqueareQubeAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }

        public string GetAnswer()
        {
            var result = new List<int>();
            foreach (var number in _parameters)
            {

                var sqrtResult = Math.Sqrt(number);
                if (Math.Round(sqrtResult) != sqrtResult)
                {
                    continue;
                }

                var qubeResult = Math.Pow(number, 1/3);
                if (Math.Round(qubeResult) != qubeResult)
                {
                    continue;
                }

                result.Add(number);
            }

            var response = result.Aggregate(string.Empty, (current, correct) => current + (correct + ','));

            return response.TrimEnd(',');
        }
    }
}
