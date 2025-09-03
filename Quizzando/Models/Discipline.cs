namespace Quizzando.Models
{
    public class Discipline
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
