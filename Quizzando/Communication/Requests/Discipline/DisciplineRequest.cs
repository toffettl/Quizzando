using Quizzando.Communication.Requests.Question;

namespace Quizzando.Communication.Requests.Disciplines
{
    public class DisciplineRequest
    {
        public string? DisciplineName { get; set; }
        public string? Description { get; set; }
        public Guid CourseId { get; set; }
        public int Difficulty { get; set; }
        public List<QuestionRequest> Questions { get; set; } = new();
    }
}
