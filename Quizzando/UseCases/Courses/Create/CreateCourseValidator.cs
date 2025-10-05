using FluentValidation;
using Quizzando.Communication.Requests.Course;
using Quizzando.Exception;

namespace Quizzando.UseCases.Courses.Create
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseValidator()
        {
            RuleFor(c => c.CourseName)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY)
                .MinimumLength(3).WithMessage(ResourceErrorMessages.NAME_TOO_SHORT);

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_EMPTY);

            RuleFor(c => c.Category)
                .IsInEnum().WithMessage(ResourceErrorMessages.CATEGORY_INVALID);

            RuleFor(c => c.Rating)
                .GreaterThanOrEqualTo(0).WithMessage(ResourceErrorMessages.RATING_INVALID);
        }
    }
}