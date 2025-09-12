using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Security.Cryptography;
using Quizzando.Security.Tokens.AccessToken;
using Quizzando.Security.Tokens.RefreshToken;

namespace Quizzando.UseCases.Authentication.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public DoLoginUseCase(
            IUserReadOnlyRepository repository,
            IPasswordEncripter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _repository = repository;
            _passwordEncripter = passwordEncripter;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<ResponseTokenJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetByEmail(request.Email!);

            if (user == null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Password!, user.Password!);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseTokenJson
            {
                AccessToken = _accessTokenGenerator.Generate(user),
                RefreshToken = _refreshTokenGenerator.Generate(user)

            };
        }
    }
}
