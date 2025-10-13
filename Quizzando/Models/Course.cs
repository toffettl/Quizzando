using Quizzando.Enums;
using System.ComponentModel;

namespace Quizzando.Models
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? BackgroundImage { get; set; }
        public Category Category { get; set; }
        public string? Icon { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}