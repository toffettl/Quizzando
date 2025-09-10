using Microsoft.EntityFrameworkCore;
using Quizzando.Models;
using Quizzando.UseCases.Courses.Create;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public class CourseRepository : ICourseWriteOnlyRepository, ICourseReadOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public CourseRepository(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Course course)
        {
            await _dbContext.course.AddAsync(course);
        }

        public async Task Update(Course course)
        {
            _dbContext.course.Update(course);
        }

        public async Task Delete(Course course)
        {
            _dbContext.course.Remove(course);
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _dbContext.course.FirstAsync(course => course.id == id); 
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _dbContext.course.ToListAsync();
        }

        public async Task<List<Course>> GetCourseByDisciplineId(Guid disciplineId)
        {
            return await _dbContext.course.Where(course => course.discipline_id == disciplineId).ToListAsync();
        }
    }
}