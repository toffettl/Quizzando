using AutoMapper;
using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.Course;
using Quizzando.Communication.Responses.User;
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
            CreateMap<CreateCourseRequest, Course>();
        }

        private void ResponseToEntity()
        {
            CreateMap<User, UserRegisterResponse>();
            CreateMap<User, UserGetByIdResponse>();
            CreateMap<Course, CreateCourseResponse>();
            CreateMap<Course, GetCourseByIdResponse>();
            CreateMap<Course, GetAllCoursesResponse>();
        }


    }
}
