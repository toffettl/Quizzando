using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.User;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Security.Cryptography;
using Quizzando.Security.Tokens;

namespace Quizzando.UseCases.Users.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(
            IUserReadOnlyRepository repository,
            IPasswordEncripter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _repository = repository;
            _passwordEncripter = passwordEncripter;
            _accessTokenGenerator = accessTokenGenerator;
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
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
