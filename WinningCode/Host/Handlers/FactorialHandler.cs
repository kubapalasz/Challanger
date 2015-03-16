using System.Globalization;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class FactorialHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::FactorialQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var number = int.Parse(question.Parameters[0]);
            var result = number;

            for (var i = 1; i < number; i++)
            {
                result *= i;
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
