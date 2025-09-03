using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.User;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Security.Tokens;
using System.Security.Claims;

namespace Quizzando.UseCases.Users.Refresh
{
    public class RefreshTokenUseCase : IRefreshTokenUseCase
    {
        private readonly ITokenValidator _tokenValidator;
        private readonly IUserReadOnlyRepository _userRepository;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public RefreshTokenUseCase(
            ITokenValidator tokenValidator,
            IUserReadOnlyRepository userRepository,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _tokenValidator = tokenValidator;
            _userRepository = userRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
        }
        public async Task<ResponseRefreshJson> Execute(RequestRefreshJson request)
        {
            var principal = _tokenValidator.Validate(request.RefreshToken!);

            if (principal == null)
                throw new UnauthorizedException(ResourceErrorMessages.INVALID_REFRESH_TOKEN);

            var userIdClaim = principal.FindFirst(ClaimTypes.Sid);

            if (userIdClaim == null)
                throw new UnauthorizedException(ResourceErrorMessages.INVALID_REFRESH_TOKEN);

            var userId = Guid.Parse(userIdClaim.Value);

            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new UnauthorizedException(ResourceErrorMessages.INVALID_REFRESH_TOKEN);

            var newAccessToken = _accessTokenGenerator.Generate(user);
            var newRefreshToken = _refreshTokenGenerator.Generator(user);

            return new ResponseRefreshJson
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
