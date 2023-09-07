using AutoMapper;
using NikoraApi.Domain.Models;
using NikoraApi.Dtos;

namespace NikoraApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginRequestDto, User>();
            CreateMap<User, LoginResponseDto>();
        }
    }
}
