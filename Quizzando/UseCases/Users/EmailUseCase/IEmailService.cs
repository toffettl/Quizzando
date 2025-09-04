namespace Quizzando.UseCases.Users.RecoverPassword
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
