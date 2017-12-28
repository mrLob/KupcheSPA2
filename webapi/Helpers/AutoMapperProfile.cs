using AutoMapper;
using webapi.DTO;
using webapi.Models;

namespace webapi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();   
        }
    }
}