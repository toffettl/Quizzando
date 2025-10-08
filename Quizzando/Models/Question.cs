namespace Quizzando.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionStatement { get; set; } = string.Empty;

        public Guid DisciplineId { get; set; }
        public Discipline? Discipline { get; set; }
        public int Difficulty { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
