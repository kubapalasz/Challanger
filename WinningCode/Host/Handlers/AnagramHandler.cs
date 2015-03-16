using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class AnagramHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::AnagramQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var word = question.Parameters[0];
            var anagrams = GetPermutations(string.Empty, word);

            const string pattern = "\\[\\\".*\\\",\\[(.*)\\]\\]";

            var match = Regex.Match(json, pattern);
            if (match.Success)
            {
                return match.Groups[1]
                    .ToString()
                    .Replace("\"", "")
                    .Split(',')
                    .First(anagrams.Contains);
            }
            
            return null;
        }

        private static IEnumerable<string> GetPermutations(string start, string text)
        {
            if (text.Length <= 1)
            {
                yield return start + text;
            }
            else
            {
                for (var i = 0; i < text.Length; i++)
                {
                    text = text[i] + text.Substring(0, i) + text.Substring(i + 1);

                    foreach (var s in GetPermutations(start + text[0], text.Substring(1)))
                    {
                        yield return s;
                    }
                }
            }
        }
    }
}
