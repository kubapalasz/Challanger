using System;
using System.Globalization;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class ArithmeticHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::AdditionQuestion"
                || question.QuestionType == "ExtremeStartup::AdditionAdditionQuestion"
                || question.QuestionType == "ExtremeStartup::SubtractionQuestion"
                || question.QuestionType == "ExtremeStartup::MultiplicationQuestion"
                || question.QuestionType == "ExtremeStartup::DivisionQuestion"
                || question.QuestionType == "ExtremeStartup::PowerQuestion"
                || question.QuestionType == "ExtremeStartup::AdditionMultiplicationQuestion"
                || question.QuestionType == "ExtremeStartup::MultiplicationAdditionQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            var a = Convert.ToDouble(question.Parameters[0]);
            var b = Convert.ToDouble(question.Parameters[1]);
            var c = (question.Parameters.Length >= 3)
                ? Convert.ToDouble(question.Parameters[2])
                : double.NaN;

            return ExecuteCalculation(question.QuestionType, a, b, c);
        }

        private static string ExecuteCalculation(string operation, double a, double b, double c = double.NaN)
        {
            double result;

            switch (operation)
            {
                case "ExtremeStartup::AdditionQuestion":
                case "ExtremeStartup::AdditionAdditionQuestion":
                    if (double.IsNaN(c))
                        c = 0;

                    result = a + b + c;

                    return result.ToString(CultureInfo.InvariantCulture);

                case "ExtremeStartup::SubtractionQuestion":
                    if (double.IsNaN(c))
                        c = 0;

                    result = a - b - c;

                    return result.ToString(CultureInfo.InvariantCulture);

                case "ExtremeStartup::MultiplicationQuestion":
                    if (double.IsNaN(c))
                        c = 1;

                    result = a * b * c;

                    return result.ToString(CultureInfo.InvariantCulture);

                case "ExtremeStartup::DivisionQuestion":
                    if (double.IsNaN(c))
                        c = 1;

                    result = a / b / c;

                    return result.ToString(CultureInfo.InvariantCulture);

                case "ExtremeStartup::PowerQuestion":
                    result = Math.Pow(a, b);

                    return result.ToString(CultureInfo.InvariantCulture);

                case "ExtremeStartup::AdditionMultiplicationQuestion":
                    if (double.IsNaN(c))
                        c = 1;

                    result = a + b * c;

                    return result.ToString(CultureInfo.InvariantCulture);

                case "ExtremeStartup::MultiplicationAdditionQuestion":
                    if (double.IsNaN(c))
                        c = 1;

                    result = a * b + c;

                    return result.ToString(CultureInfo.InvariantCulture);
            }

            return null;
        }
    }
}
