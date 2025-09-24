namespace Quizzando.Communication.Responses.User
{
    public class UserGetByRankingResponse
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public int Score { get; set; }

    }
}
