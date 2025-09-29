namespace Quizzando.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }

        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
