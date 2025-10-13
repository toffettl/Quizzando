namespace Quizzando.UseCases.UserDisciplineRelations.RecoverEmail.SendEmailUseCase
{
    public interface ISendEmailUseCase
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
