using Quizzando.DataAccess.Repositories.UserRepositories;

namespace Quizzando.UseCases.Users.ResetPassword
{
    public class ResetPasswordUseCase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public ResetPasswordUseCase(IJwtService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public async Task<bool> ExecuteAsync(string token, string code, string newPassword)
        {
            var claims = _jwtService.ValidateToken(token);
            if (claims == null) return false;

            var codeFromToken = claims["resetCode"];
            if (codeFromToken != code) return false;

            var email = claims["sub"];
            await _userRepository.UpdatePasswordAsync(email, newPassword);

            return true;
        }
    }
}
