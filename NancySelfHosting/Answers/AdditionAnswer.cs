using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class AdditionAnswer: IAnswer
    {
        private int[] _parameters;

        public AdditionAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }
        public string GetAnswer()
        {
            int sum = _parameters.Sum();
            return sum.ToString();
        }
    }
}
