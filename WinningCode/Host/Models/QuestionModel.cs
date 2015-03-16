namespace GeekUp.Host.Models
{
    public sealed class QuestionModel
    {
        public string QuestionType { get; set; }

        public string Question { get; set; }

        public string[] Parameters { get; set; }

        public int Points { get; set; }
    }
}
