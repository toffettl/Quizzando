namespace Quizzando.Communication.Responses.User
{
    public class UserGetByIdResponse
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int Score { get; set; }
        public bool Admin { get; set; }


    }
}
