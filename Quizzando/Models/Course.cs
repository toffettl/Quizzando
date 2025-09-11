namespace Quizzando.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }

        public Guid DisciplineId { get; set; }
        public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}