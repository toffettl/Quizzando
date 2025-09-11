namespace Quizzando.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? Course_name { get; set; }

        public Guid Discipline_id { get; set; }
        public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}