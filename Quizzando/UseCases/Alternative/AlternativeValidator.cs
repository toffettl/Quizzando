using FluentValidation;
using Quizzando.Communication.Requests.Alternatives;
using Quizzando.Exception;

namespace Quizzando.UseCases.Alternative
{
    public class AlternativeValidator : AbstractValidator<AlternativeRequest>
    {
        public AlternativeValidator()
        {
            RuleFor(alternative => alternative.AlternativeText)
                .NotEmpty().WithMessage(ResourceErrorMessages.TEXT_EMPTY);

            RuleFor(alternative => alternative.AlternativeText)
                .MaximumLength(50).WithMessage(ResourceErrorMessages.TEXT_MAX_LENGTH);
        }
    }
}
