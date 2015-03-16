using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class MaxAnswer : IAnswer
    {
        private int[] _parameters;

        public MaxAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }
        public string GetAnswer()
        {
           int max = Int32.MinValue;
           foreach (var number in _parameters)
           {
               if (number> max)
               {
                   max = number;
               }

           }
           return max.ToString();
        }
    }
}
