using Microsoft.EntityFrameworkCore;

namespace Quizzando.DataAccess
{
    public class QuizzandoDbContext : DbContext
    {
        public QuizzandoDbContext(DbContextOptions<QuizzandoDbContext> options)
            : base(options)
        {
        }


    }
}
