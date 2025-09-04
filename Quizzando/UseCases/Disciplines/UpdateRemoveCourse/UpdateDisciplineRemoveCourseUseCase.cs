using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.Exception;

namespace Quizzando.UseCases.Disciplines.UpdateRemoveCourse
{
    public class UpdateDisciplineRemoveCourseUseCase : IUpdateDisciplineRemoveCourseUseCase
    {
        private readonly IDisciplineReadOnlyRepository _disciplineReadOnlyRepository;
        private readonly IDisciplineUpdateOnlyRepository _disciplineUpdateOnlyRepository;
        private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDisciplineRemoveCourseUseCase(
            IDisciplineReadOnlyRepository disciplineReadOnlyRepository,
            IDisciplineUpdateOnlyRepository disciplineUpdateOnlyRepository,
            ICourseReadOnlyRepository courseReadOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _disciplineReadOnlyRepository = disciplineReadOnlyRepository;
            _disciplineUpdateOnlyRepository = disciplineUpdateOnlyRepository;
            _courseReadOnlyRepository = courseReadOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id, Guid courseId)
        {
            var discipline = await _disciplineReadOnlyRepository.GetById(id);

            if (discipline == null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.DISCIPLINE_NOT_FOUND);
            }

            var course = await _courseReadOnlyRepository.GetCourseById(courseId);

            if (course == null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }

            Console.WriteLine(discipline.Courses.Count());

            discipline.Courses.Remove(course);

            Console.WriteLine(discipline.Courses.Count());

            _disciplineUpdateOnlyRepository.Update(discipline);

            await _unitOfWork.Commit();
        }
    }
}
