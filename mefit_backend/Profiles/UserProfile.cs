using mefit_backend.Models.DTO.User;
using Microsoft.Extensions.Options;
using AutoMapper;
using mefit_backend.models.domain;

namespace mefit_backend.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDTO, User>();
            CreateMap<PutUserDTO, User>();
            CreateMap<User, GetUserDTO>();
            CreateMap<PasswordDTO, User>();
            //.ForMember(dto => dto.Profile, options =>
            //options.MapFrom(userDomain => $"api/v1/profile/{userDomain.Profile}"));
        }
    }
}
