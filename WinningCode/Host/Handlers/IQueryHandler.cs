using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public interface IQueryHandler
    {
        bool CanHandle(QuestionModel question);

        string Handle(QuestionModel question, string json);
    }
}
