﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class MultiplyAddAnswer : IAnswer
    {
        private int[] _parameters;

        public MultiplyAddAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }

        public string GetAnswer()
        {
            int ans = _parameters[0] * _parameters[1] + _parameters[2];
            return ans.ToString();
        }
    }
}
