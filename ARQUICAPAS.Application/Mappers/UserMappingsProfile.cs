using ARQUICAPAS.Application.Dtos.User.Request;
using ARQUICAPAS.Domain.Entities;
using AutoMapper;

namespace ARQUICAPAS.Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<TokenRequestDto, User>();
        }
    }
}
