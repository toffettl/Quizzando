using AutoMapper;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.Question;
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
            CreateMap<QuestionRequest, Question>();
        }

        private void ResponseToEntity()
        {
            CreateMap<User, UserRegisterResponse>();
            CreateMap<User, UserGetByIdResponse>();
            CreateMap<Question, QuestionResponse>();
        }


    }
}
