using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class PowerAnswer
    {
        private int[] _parameters;

        public PowerAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }

        public string GetAnswer()
        {
            return Math.Pow(Convert.ToDouble(_parameters[0]), Convert.ToDouble(_parameters[1])).ToString();
        }
    }
}
