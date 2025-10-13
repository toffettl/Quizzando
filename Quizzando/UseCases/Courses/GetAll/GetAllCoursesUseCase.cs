using AutoMapper;
using Quizzando.Communication.Responses.Course;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Courses.GetAll
{
    public class GetAllCoursesUseCase : IGetAllCoursesUseCase
    {
            private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
            private readonly IMapper _mapper;
            
        public GetAllCoursesUseCase(
            ICourseReadOnlyRepository courseReadOnlyRepository,
            IMapper mapper
            )
        {
            _courseReadOnlyRepository = courseReadOnlyRepository;
            _mapper = mapper;
        }
        
        public async Task<GetAllCoursesResponse> Execute()
        {
            var courses = await _courseReadOnlyRepository.GetAllCourses();

            if (courses == null)
            {
                throw new NotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }

            return new GetAllCoursesResponse
            {
                Courses = _mapper.Map<List<CourseResponseJson>>(courses)
            };
        }
    }
}