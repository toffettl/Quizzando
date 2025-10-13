using Quizzando.Enums;

namespace Quizzando.Communication.Requests.Course
{
    public class CreateCourseRequest
    {
        public string? CourseName { get; set; }
        public string? BackgroundImage { get; set; }
        public string? Description { get; set; }    
        public Category Category { get; set; }
        public string? Icon { get; set; }
        public int Rating { get; set; }
    }
}