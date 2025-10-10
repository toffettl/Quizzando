using FluentValidation;
using Quizzando.Communication.Requests.Disciplines;
using Quizzando.Exception;

namespace Quizzando.UseCases.Disciplines
{
    public class DisciplineValidator : AbstractValidator<DisciplineRequest>
    {
        public DisciplineValidator()
        {
            RuleFor(discipline => discipline.DisciplineName)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        }
    }
}
