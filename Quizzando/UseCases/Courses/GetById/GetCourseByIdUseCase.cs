using AutoMapper;
using Quizzando.Communication.Responses.Course;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Courses.GetById
{
    public class GetCourseByIdUseCase : IGetCourseByIdUseCase
    {
        private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetCourseByIdUseCase(ICourseReadOnlyRepository courseReadOnlyRepository,
            IMapper mapper
            )
        {
            _courseReadOnlyRepository = courseReadOnlyRepository;
            _mapper = mapper;
        }
        
        public async Task<GetCourseByIdResponse> Execute(Guid id)
        {
            var course = await _courseReadOnlyRepository.GetCourseById(id);

            if (course == null)
            {
                throw new NotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }

            return _mapper.Map<GetCourseByIdResponse>(course);
        }
    }
}