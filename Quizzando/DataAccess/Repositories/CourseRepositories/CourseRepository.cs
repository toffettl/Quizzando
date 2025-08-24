using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

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
            await _dbContext.Course.AddAsync(course);
        }

        public async Task Update(Course course)
        {
            _dbContext.Course.Update(course);
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _dbContext.Course.FirstAsync(course => course.Id == id); 
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _dbContext.Course.ToListAsync();
        }
    }
}