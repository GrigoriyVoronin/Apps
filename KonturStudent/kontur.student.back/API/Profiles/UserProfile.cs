using API.Models;
using API.Models.UserDto;
using AutoMapper;
using KSRepositories.DbModels;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserRequest, User>();
        }
    }
}