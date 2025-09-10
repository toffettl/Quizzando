namespace Quizzando.Models
{
    public class Question
    {
        public Guid id { get; set; }
        public string? question_statement { get; set; }
        public Guid dscipline_id { get; set; }
        public Discipline? discipline { get; set; }
    }
}
