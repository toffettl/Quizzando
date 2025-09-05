namespace Quizzando.UseCases.RecoverEmail.EmailUseCase
{
    public interface ISendEmailUseCase
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
