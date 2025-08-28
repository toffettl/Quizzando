using FluentValidation;
using Quizzando.Communication.Requests.User;
using Quizzando.Exception;

namespace Quizzando.UseCases.Users.Update
{
    public class UpdateUserValidator : AbstractValidator<UserUpdateRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        }
    }
}
