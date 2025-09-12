namespace Quizzando.Communication.Responses.Alternatives
{
    public class AlternativeResponse
    {
        public Guid Id { get; set; }
        public string? AlternativeText { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
