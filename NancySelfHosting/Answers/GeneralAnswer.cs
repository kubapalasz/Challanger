using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancySelfHosting.Answers
{
    public class GeneralAnswer : IAnswer
    {
        private string _question;
        public GeneralAnswer(string question)
        {
            _question = question;
        }
        public string GetAnswer()
        {
            if (_question.Contains("Dr No"))
            {
                return "Sean Connery";
            }
            if (_question.Contains("banana"))
            {
                return "yellow";
            }
            if (_question.Contains("Prime Minister"))
            {
                return "David Cameron";
            }
            if (_question.Contains("Eiffel"))
            {
                return "Paris";
            }
            return "20";
        }
    }
}
