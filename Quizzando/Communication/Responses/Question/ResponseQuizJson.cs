namespace Quizzando.Communication.Responses.Question
{
    public class ResponseQuizJson
    {
        public Guid DisciplineId { get; set; }
        public List<QuestionResponse> Questions { get; set; } = new();
    }
}
