namespace Quizzando.Models
{
    public class UserDiscipline
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public long Time { get; set; }

        public Guid UserId { get; set; }
        public Guid DisciplineId { get; set; }

        public User? User { get; set; }
        public Discipline? Discipline { get; set; }
    }
}
