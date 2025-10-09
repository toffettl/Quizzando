namespace Quizzando.Communication.Requests.Question
{
    public class QuestionRequest
    {
        public string QuestionStatement { get; set; } = null!;
        public int Difficulty { get; set; }
        public List<AnswerRequest> Answers { get; set; } = new();
    }
}
