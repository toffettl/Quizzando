using Quizzando.Enums;

namespace Quizzando.Communication.Responses.Course
{
    public class CourseResponse
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? BackgroundImage { get; set; }
        public string? Icon { get; set; }
        public CourseCategory Category { get; set; }
        public int Rating { get; set; }
        public List<Guid>? Disciplines { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}