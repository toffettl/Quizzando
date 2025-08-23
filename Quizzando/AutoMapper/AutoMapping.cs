using AutoMapper;
using Quizzando.Communication.Requests.User;
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
        }

        private void ResponseToEntity()
        {
            CreateMap<User, UserRegisterResponse>();
            CreateMap<User, UserGetByIdResponse>();
        }


    }
}
