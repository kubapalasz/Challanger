using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class MultiplicationAnswer : IAnswer
    {
        private int[] _parameters;

        public MultiplicationAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }
        public string GetAnswer()
        {
           var result = 1;
           foreach (var number in _parameters)
           {
               result *= number;

           }
           return result.ToString();
        }
    }
}
