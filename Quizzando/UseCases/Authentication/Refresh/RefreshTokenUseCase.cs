using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Security.Tokens.AccessToken;
using Quizzando.Security.Tokens.RefreshToken;

namespace Quizzando.UseCases.Authentication.Refresh
{
    public class RefreshTokenUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenValidator _refreshTokenValidator;

        public RefreshTokenUseCase(
            IUserReadOnlyRepository repository,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenValidator refreshTokenValidator)
        {
            _repository = repository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenValidator = refreshTokenValidator;
        }

        public async Task<ResponseTokenJson> Execute(RequestRefreshTokenJson request)
        {
            // 1. Valida refresh token
            var userId = _refreshTokenValidator.Validate(request.RefreshToken);

            if (userId == Guid.Empty)
                throw new();

            // 2. Busca usuário pelo Id
            var user = await _repository.GetUserById(userId);

            if (user == null)
                throw new ();

            return new ResponseTokenJson
            {
                AccessToken = _accessTokenGenerator.Generate(user),
                RefreshToken = _refreshTokenGenerator.Generate(user)
            };
        }
    }
}