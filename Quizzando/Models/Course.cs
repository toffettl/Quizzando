using Quizzando.Enums;

namespace Quizzando.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? BackgroundImage { get; set; }
        public string? Icon { get; set; }
        public CourseCategory Category { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}