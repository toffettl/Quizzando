namespace Quizzando.Communication.Requests.Course
{
    public class CreateCourseRequest
    {
        public string? courseName { get; set; }
        public Guid DisciplineId { get; set; }
    }
}