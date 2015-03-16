using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class AnagramAnswer : IAnswer
    {
        private string[] _parameters;

        public AnagramAnswer(string parameters)
        {
            var strings = parameters.Split('"');
            _parameters = new string[strings.Length/2];
            _parameters[0] = strings[1];
            for (int i = 3; i < strings.Length; i += 2)
            {
                _parameters[i/2] = strings[i];
            }
        }

        public static bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            if (s1.Length != s2.Length)
                return false;

            foreach (char c in s2)
            {
                int ix = s1.IndexOf(c);
                if (ix >= 0)
                    s1 = s1.Remove(ix, 1);
                else
                    return false;
            }

            return string.IsNullOrEmpty(s1);
        }

        public string GetAnswer()
        {
            var answer = "";
            for (int i = 1; i < _parameters.Length; i++)
            {
                if (IsAnagram(_parameters[0], _parameters[i]))
                {
                    answer =   _parameters[i] ;
                }
            }
            return answer;
        }
    }
}
