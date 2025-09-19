using Microsoft.EntityFrameworkCore;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Security.Cryptography;
using Quizzando.Security.Tokens.AccessToken;
using Quizzando.UseCases.Courses.Create;
using Quizzando.UseCases.Courses.Delete;
using Quizzando.UseCases.Courses.GetAll;
using Quizzando.UseCases.Courses.GetById;
using Quizzando.UseCases.Courses.Update;
using Quizzando.UseCases.Disciplines.Create;
using Quizzando.UseCases.Disciplines.Delete;
using Quizzando.UseCases.Disciplines.GetAll;
using Quizzando.UseCases.Disciplines.GetById;
using Quizzando.UseCases.Disciplines.Update;
using Quizzando.UseCases.UserDisciplineRelations.Delete;
using Quizzando.UseCases.UserDisciplines.Create;
using Quizzando.UseCases.UserDisciplines.GetByUserIdAndDisciplineId;
using Quizzando.UseCases.Users.Delete;
using Quizzando.UseCases.Users.Get.All;
using Quizzando.UseCases.Users.Get.ById;
using Quizzando.UseCases.Users.Login;
using Quizzando.UseCases.Users.Register;
using Quizzando.UseCases.Users.Update;

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
            AddToken(services, configuration);
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
            services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
            services.AddScoped<IDisciplineReadOnlyRepository, DisciplineRepository>();
            services.AddScoped<IDisciplineWriteOnlyRepository, DisciplineRepository>();
            services.AddScoped<IDisciplineUpdateOnlyRepository, DisciplineRepository>();
            services.AddScoped<IUserDisciplineRelationWriteOnlyRepository, UserDisciplineRelationRepository>();
            services.AddScoped<IUserDisciplineRelationReadOnlyRepository, UserDisciplineRelationRepository>();
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
            services.AddScoped<IUpdateCourseUseCase, UpdateCourseUseCase>();
            services.AddScoped<IDeleteCourseUseCase, DeleteCourseUseCase>();
            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();    
            services.AddScoped<IUpdateDisciplineUseCase, UpdateDisciplineUseCase>();
            services.AddScoped<ICreateDisciplineUseCase, CreateDisciplineUseCase>();
            services.AddScoped<IDeleteDisciplineUseCase, DeleteDisciplineUseCase>();
            services.AddScoped<IGetAllDisciplinesUseCase, GetAllDisciplinesUseCase>();
            services.AddScoped<IGetDisciplineByIdUseCase, GetDisciplineByIdUseCase>();
            services.AddScoped<IUpdateDisciplineUseCase, UpdateDisciplineUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypto>();
            services.AddScoped<ICreateUserDisciplineUseCaseRelation, CreateUserDisciplineUseCaseRelation>();
            services.AddScoped<IDeleteUserDisciplineRelationUseCase, DeleteUserDisciplineRelationUseCase>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var signingKey = configuration["Jwt:Key"];
            var expirationTimeMinutes = Convert.ToUInt32(configuration["Jwt:ExpirationMinutes"]);

            services.AddScoped<IAccessTokenGenerator>(config => new AccessTokenGenerator(expirationTimeMinutes, signingKey!));
        }
    }
}
