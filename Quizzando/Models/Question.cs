namespace Quizzando.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? QuestionStatement { get; set; }
        public Guid DisciplineId { get; set; }
        public Discipline? Discipline { get; set; }
    }
}
