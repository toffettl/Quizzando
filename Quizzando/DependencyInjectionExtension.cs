using Microsoft.EntityFrameworkCore;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.UseCases.Disciplines.Create;
using Quizzando.UseCases.Users.GetById;
using Quizzando.UseCases.Users.Register;

namespace Quizzando
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddAutoMapper(services);
            AddUseCases(services);
        }


        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IDisciplineWriteOnlyRepository, DisciplineRepository>();
            services.AddScoped<IDisciplineReadOnlyRepository, DisciplineRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<QuizzandoDbContext>(config =>
                config.UseNpgsql(conectionString));
        }

        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
            services.AddScoped<ICreateDisciplineUseCase, CreateDisciplineUseCase>();
        } 
    }
}
