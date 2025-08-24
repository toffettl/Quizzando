using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.UseCases.Courses.Create;
using Quizzando.UseCases.Courses.GetAll;
using Quizzando.UseCases.Courses.GetById;
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
            services.AddScoped<ICourseWriteOnlyRepository, CourseRepository>();
            services.AddScoped<ICourseReadOnlyRepository, CourseRepository>();
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
            services.AddScoped<ICreateCourseUseCase, CreateCourseUseCase>();
            services.AddScoped<IGetCourseByIdUseCase, GetCourseByIdUseCase>();
            services.AddScoped<IGetAllCoursesUseCase,  GetAllCoursesUseCase>();

        } 
    }
}
