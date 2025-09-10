namespace Quizzando.Communication.Requests.Authentication
{
    public class UserRegisterRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
