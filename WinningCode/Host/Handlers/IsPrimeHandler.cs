using System;
using System.Linq;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class IsPrimeHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::PrimesQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var numbers = question.Parameters.Select(int.Parse).Where(IsPrime);
            return string.Join(", ", numbers);
        }

        private static bool IsPrime(int number)
        {
            if (number == 1)
                return false;

            if (number == 2)
                return true;

            for (var i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
