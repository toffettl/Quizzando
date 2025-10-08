using Quizzando.Enums;
using System.ComponentModel;

namespace Quizzando.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? BackgroundImage { get; set; }
        public Category Category { get; set; }
        public string? Icon { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}