using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess
{
    public class QuizzandoDbContext : DbContext
    {
        public QuizzandoDbContext(DbContextOptions<QuizzandoDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User {  get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Course> Course { get; set; }
        
        public DbSet<RefreshToken>  RefreshToken { get; set; }
    }
}
