namespace Quizzando.Communication.Responses.Course
{
    public class CourseResponseJson
    {
        public Guid Id { get; set; }
        public string? courseName { get; set; }
        public Guid DisciplineId { get; set; }

    }
}