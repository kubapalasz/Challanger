using GeekUp.Host.Models;

namespace GeekUp.Host.Handlers
{
    public sealed class GeneralKnowledgeHandler : IQueryHandler
    {
        public bool CanHandle(QuestionModel question)
        {
            return question.QuestionType == "ExtremeStartup::GeneralKnowledgeQuestion";
        }

        public string Handle(QuestionModel question, string json)
        {
            switch (question.Question)
            {
                case "who played James Bond in the film Dr No":
                    return "Sean Connery";

                case "who is the Prime Minister of Great Britain":
                    return "David Cameron";

                case "what currency did Spain use before the Euro":
                    return "Peseta";

                case "what colour is a banana":
                    return "yellow";
            }

            return null;
        }
    }
}
