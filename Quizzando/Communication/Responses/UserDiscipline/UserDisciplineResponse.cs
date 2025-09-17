namespace Quizzando.Communication.Responses.UserDiscipline
{
    public class UserDisciplineResponse
    {
        public Guid Id { get; set; }
        public long Time { get; set; }
        public Guid UserId { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
