namespace Quizzando.Models
{
    public class Course
    {
        public Guid id { get; set; }
        public string? course_name { get; set; }

        public Guid discipline_id { get; set; }
        public ICollection<Discipline> disciplines { get; set; } = new List<Discipline>();
    }
}