using Microsoft.Extensions.Options;
using AutoMapper;
using mefit_backend.Models.DTO.ProfileDtos;
using mefit_backend.models.domain;

namespace mefit_backend.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<CreateProfileDTO, models.domain.Profile>();
            CreateMap<PutProfileDTO, models.domain.Profile>();
            CreateMap<models.domain.Profile, GetProfileDTO>()
                .ForMember(dto => dto.Goals, options =>
                options.MapFrom(goalDomain => goalDomain.Goals.Select(goal => $"api/v1/goal/{goal.Id}").ToList()))
                .ForMember(dto => dto.Impairments, options =>
                options.MapFrom(impairmentDomain => impairmentDomain.Impairments.Select(impairment => $"api/v1/impairment/{impairment.Id}").ToList()));
        }
    }
}
