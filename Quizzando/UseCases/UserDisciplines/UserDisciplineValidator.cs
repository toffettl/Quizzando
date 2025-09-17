using FluentValidation;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Exception;

namespace Quizzando.UseCases.UserDisciplines
{
    public class UserDisciplineValidator : AbstractValidator<UserDisciplineRequest>
    {
        public UserDisciplineValidator() 
        {
            RuleFor(request => request.Time)
                .NotNull().WithMessage(ResourceErrorMessages.TIME_NULL);
        }
    }
}
