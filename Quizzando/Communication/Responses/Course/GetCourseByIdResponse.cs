using Quizzando.Enums;

namespace Quizzando.Communication.Responses.Course
{
    public class GetCourseByIdResponse
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public string? BackgroundImage { get; set; }
        public Category Category { get; set; }
        public string? Icon { get; set; }
        public int Rating { get; set; }
    }
}