using System;
using System.Globalization;
using System.Linq;
using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class SquareCubeHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::SquareCubeQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            foreach (var number in question.Parameters.Select(int.Parse))
            {
                var sq = Math.Sqrt(number);
                var cub = Math.Pow(number, 1 / 3);

                if ((sq % 1 == 0) && (cub % 1 == 0))
                {
                    return number.ToString(CultureInfo.InvariantCulture);
                }
            }

            return null;
        }
    }
}
