namespace Quizzando.Models
{
    public class Discipline
    {
        public Guid id { get; set; } = Guid.NewGuid();

        public string? name { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        public Guid Courses_Id { get; set; }

        public ICollection<Question> questions { get; set; } = new List<Question>();
        public ICollection<Course> courses { get; set; } = new List<Course>();
    }
}
