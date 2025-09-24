namespace Quizzando.Communication.Requests.Email;

public class ResetPassworRequest
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
