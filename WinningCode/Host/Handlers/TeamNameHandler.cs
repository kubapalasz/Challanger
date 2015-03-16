using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class TeamNameHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::WarmupQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            return "TeamH";
        }
    }
}
