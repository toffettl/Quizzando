using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.UseCases.Questions.Create;
using Quizzando.UseCases.Questions.Delete;
using Quizzando.UseCases.Questions.GetAll;
using Quizzando.UseCases.Questions.GetById;
using Quizzando.UseCases.Questions.UpdateById;
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
            services.AddScoped<IQuestionWriteOnlyRepository, QuestionRepository>();
            services.AddScoped<IQuestionReadOnlyRepository, QuestionRepository>();
            services.AddScoped<IQuestionUpdateOnlyRepository, QuestionRepository>();
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
            services.AddScoped<ICreateQuestionUseCase, CreateQuestionUseCase>();
            services.AddScoped<IGetAllQuestionsUseCase, GetAllQuestionsUseCase>();
            services.AddScoped<IGetByIdQuestionUseCase, GetByIdQuestionUseCase>();
            services.AddScoped<IUpdateByIdQuestionUseCase, UpdateByIdQuestionUseCase>();
            services.AddScoped<IDeleteQuestionUseCase, DeleteQuestionUseCase>();
        } 
    }
}
