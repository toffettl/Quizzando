namespace Quizzando.Communication.Requests.Question
{
    public class RequestQuizJson
    {
        public Guid DisciplineId { get; set; }
        public int Quantity { get; set; } = 5;
    }
}
