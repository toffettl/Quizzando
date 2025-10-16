namespace Quizzando.Communication.Responses.Discipline
{
    public class DisciplineResponse
    {
        public Guid Id { get; set; }

        public string? DisciplineName { get; set; }
        public string? Description { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
