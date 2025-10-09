namespace Quizzando.Communication.Requests.Question
{
    public class AnswerRequest
    {
        public string AnswerText { get; set; } = null!;
        public bool IsCorrect { get; set; }
    }
}
