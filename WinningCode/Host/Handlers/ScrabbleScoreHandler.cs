using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class ScrabbleScoreHandler : IQueryHandler
    {
        private readonly Dictionary<char, int> _scores = new Dictionary<char, int>
        {
            { 'a', 1 },
            { 'b', 3 },
            { 'c', 3 },
            { 'd', 2 },
            { 'e', 1 },
            { 'f', 4 },
            { 'g', 2 },
            { 'h', 4 },
            { 'i', 1 },
            { 'j', 8 },
            { 'k', 4 },
            { 'l', 1 },
            { 'm', 3 },
            { 'n', 1 },
            { 'o', 1 },
            { 'p', 3 },
            { 'q', 10 },
            { 'r', 1 },
            { 's', 1 },
            { 't', 1 },
            { 'u', 1 },
            { 'v', 4 },
            { 'w', 4 },
            { 'x', 8 },
            { 'y', 4 },
            { 'z', 10 }
        };

        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::ScrabbleQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var word = question.Parameters[0];
            return CalculateScore(word).ToString(CultureInfo.InvariantCulture);
        }

        private int CalculateScore(string word)
        {
            var letters = word.ToLower().ToCharArray();
            return letters.Sum(letter => _scores[letter]);
        }
    }
}
