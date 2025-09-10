using AutoMapper;
using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Responses.Course;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Courses.Update
{
    public class UpdateCourseUseCase : IUpdateCourseUseCase
    {
        private readonly ICourseWriteOnlyRepository _courseWriteOnlyRepository;
        private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCourseUseCase(
            ICourseWriteOnlyRepository courseWriteOnlyRepository,
            ICourseReadOnlyRepository courseReadOnlyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _courseWriteOnlyRepository = courseWriteOnlyRepository;
            _courseReadOnlyRepository = courseReadOnlyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCourseResponse> Execute(Guid id, UpdateCourseRequest request)
        {
            await Validate(request);

            var course = await _courseReadOnlyRepository.GetCourseById(id);

            if (course == null)
            {
                throw new NotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }

            course.course_name = request.courseName;

            await _courseWriteOnlyRepository.Update(course);
            await _unitOfWork.Commit();

            return _mapper.Map<UpdateCourseResponse>(course);
        }

        private async Task Validate(UpdateCourseRequest request)
        {
            var result = new UpdateCourseValidator().Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }

            await Task.CompletedTask;
        }
    }
}
