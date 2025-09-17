namespace Quizzando.Communication.Requests.UserDiscipline
{
    public class UserDisciplineRequest
    {
        public long Time { get; set; }

        public Guid UserId { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
