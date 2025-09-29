namespace Quizzando.Communication.Responses.Answer
{
    public class ResponseAnswerJson
    {
        public Guid Id { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
