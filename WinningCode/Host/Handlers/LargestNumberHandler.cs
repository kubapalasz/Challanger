using System.Globalization;
using System.Linq;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class LargestNumberHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::MaximumQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            return question.Parameters
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .FirstOrDefault()
                .ToString(CultureInfo.InvariantCulture);
        }
    }
}
