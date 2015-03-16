using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class ScrabbleAnswer : IAnswer
    {
        private string[] _parameters;

        public ScrabbleAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<string[]>(parameters);
        }

        public string GetAnswer()
        {
            return ScrabbleScore(_parameters[0]);
        }

        public static string ScrabbleScore(string word)
        {
            word = word.ToUpper();
            var scores = new Dictionary<char, int>
           {
               {'A', 1},
               {'B', 3},
               {'C', 3},
               {'D', 2},
               {'E', 1},
               {'F', 4},
               {'G', 2},
               {'H', 4},
               {'I', 1},
               {'J', 8},
               {'K', 5},
               {'L', 1},
               {'M', 2},
               {'N', 1},
               {'O', 1},
               {'P', 2},
               {'Q', 10},
               {'R', 1},
               {'S', 1},
               {'T', 1},
               {'U', 1},
               {'V', 4},
               {'W', 4},
               {'X', 8},
               {'Y', 4},
               {'Z', 10},

           };

            var sum = 0;
            for (var i = 0; i < word.Length; ++i)
            {

                sum += scores.Where(c => c.Key == word[i]).FirstOrDefault().Value;
            }
            return sum.ToString();
        }
    }
}
