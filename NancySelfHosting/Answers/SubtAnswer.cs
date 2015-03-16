using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class SubtAnswer : IAnswer
    {
        private int[] _parameters;

        public SubtAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }
        public string GetAnswer()
        {
            int sum = _parameters[0];
            for (int i = 1; i < _parameters.Length; i++ )
            {
                sum -= _parameters[i];
            }
            return sum.ToString();
        }
    }
}
