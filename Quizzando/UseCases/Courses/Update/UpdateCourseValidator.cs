using FluentValidation;
using Quizzando.Communication.Requests.Course;
using Quizzando.Exception;

namespace Quizzando.UseCases.Courses.Update
{
    public class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
    {
        public UpdateCourseValidator()
        {
            RuleFor(course => course.courseName)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY)
                .MinimumLength(3).WithMessage(ResourceErrorMessages.NAME_TOO_SHORT);
        }
    }
}