using Quizzando.Models;

namespace Quizzando.Models
{
    public class Alternative
    {
        public Guid Id { get; set; }
        public string? AlternativeText { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
