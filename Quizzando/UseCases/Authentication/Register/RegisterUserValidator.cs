using FluentValidation;
using Quizzando.Communication.Requests.Authentication;
using Quizzando.Exception;

namespace Quizzando.UseCases.Authentication.Register
{
    public class RegisterUserValidator : AbstractValidator<UserRegisterRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALID);

            RuleFor(user => user.Password).SetValidator(new PasswordValidator<UserRegisterRequest>()!);
        }
    }
}
