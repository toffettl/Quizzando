using FluentValidation;
using Quizzando.Communication.Requests.Question;
using Quizzando.Exception;

namespace Quizzando.UseCases.Questions
{
    public class QuestionValidator : AbstractValidator<QuestionRequest>
    {
        public QuestionValidator()
        {
            RuleFor(request => request.QuestionStatement)
                .NotEmpty().WithMessage(ResourceErrorMessages.QUESTION_STATEMENT_EMPTY);
        }
    }
}
