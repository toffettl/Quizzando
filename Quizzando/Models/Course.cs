namespace Quizzando.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? BackgroundImage { get; set; }
        public int Category { get; set; }
        public string? Icon { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}