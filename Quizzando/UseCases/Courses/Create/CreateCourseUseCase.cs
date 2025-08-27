using AutoMapper;
using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Responses.Course;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Models;

namespace Quizzando.UseCases.Courses.Create
{
    public class CreateCourseUseCase : ICreateCourseUseCase
    {
        private readonly ICourseWriteOnlyRepository _courseWriteOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCourseUseCase(ICourseWriteOnlyRepository courseWriteOnlyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
        )
        {
            _courseWriteOnlyRepository = courseWriteOnlyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateCourseResponse> Execute(CreateCourseRequest request)
        {
            await Validate(request);
            
            var course = _mapper.Map<Course>(request);

            await _courseWriteOnlyRepository.Add(course);

            await _unitOfWork.Commit();

            return _mapper.Map<CreateCourseResponse>(course);
        }

        private async Task Validate(CreateCourseRequest request)
        {
            var result = new CreateCourseValidator().Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}