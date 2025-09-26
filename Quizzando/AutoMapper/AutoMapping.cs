using AutoMapper;
using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Requests.Disciplines;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses.Course;
using Quizzando.Communication.Responses.Disciplines;
using Quizzando.Communication.Responses.Question;
using Quizzando.Communication.Responses.User;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.Models;

namespace Quizzando.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            RequestToEntity();
            ResponseToEntity();
        }
        private void RequestToEntity()
        {
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();
            CreateMap<DisciplineRequest, Discipline>();
            CreateMap<UserDisciplineRelationRequest, UserDisciplineRelation>();
            CreateMap<QuestionRequest, Question>();
        }

        private void ResponseToEntity()
        {
            CreateMap<User, UserRegisterResponse>();
            CreateMap<User, UserGetByIdResponse>();
            CreateMap<Course, CreateCourseResponse>();
            CreateMap<Course, GetCourseByIdResponse>();
            CreateMap<Course, GetAllCoursesResponse>();
            CreateMap<Course, UpdateCourseResponse>();
            CreateMap<Discipline, DisciplineResponse>();
            CreateMap<UserDisciplineRelation, UserDisciplineRelationResponse>();
            CreateMap<Question, QuestionResponse>();
        }


    }
}
