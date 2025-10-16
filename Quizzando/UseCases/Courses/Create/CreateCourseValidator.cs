using FluentValidation;
using Quizzando.Communication.Requests.Course;
using Quizzando.Exception;

namespace Quizzando.UseCases.Courses.Create
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseValidator()
        {
            RuleFor(course => course.courseName)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY)
                .MinimumLength(3).WithMessage(ResourceErrorMessages.NAME_TOO_SHORT);
        }
    }
}