namespace Quizzando.Models
{
    public class Discipline
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? DisciplineName { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid CourseId { get; set; }
 
        public Course? Course { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
