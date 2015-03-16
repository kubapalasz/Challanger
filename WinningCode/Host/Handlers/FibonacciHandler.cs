using System;
using System.Globalization;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class FibonacciHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::FibonacciQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var number = int.Parse(question.Parameters[0]) - 1;
            return Fibonacci(number).ToString(CultureInfo.InvariantCulture);
        }

        public static ulong Fibonacci(int n)
        {
            var sqrt5 = Math.Sqrt(5);
            var p1 = (1 + sqrt5) / 2;
            var p2 = -1 * (p1 - 1);

            var n1 = Math.Pow(p1, n + 1);
            var n2 = Math.Pow(p2, n + 1);

            return (ulong)((n1 - n2) / sqrt5);
        }
    }
}
