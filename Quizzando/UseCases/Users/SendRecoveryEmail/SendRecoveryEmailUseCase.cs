using Quizzando.UseCases.Users.RecoverPassword;

namespace Quizzando.UseCases.Users.SendRecoveryEmail
{
    public class SendRecoveryEmailUseCase
    {
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;

        public SendRecoveryEmailUseCase(IEmailService emailService, IJwtService jwtService)
        {
            _emailService = emailService;
            _jwtService = jwtService;
        }

        public async Task<string> ExecuteAsync(string email)
        {
            var code = new Random().Next(10000, 99999).ToString();

            await _emailService.SendEmailAsync(email, "Recuperação de senha",
                $"Seu código de verificação é: <b>{code}</b>");

            return _jwtService.GeneratePasswordResetToken(email, code);
        }
    }

}
