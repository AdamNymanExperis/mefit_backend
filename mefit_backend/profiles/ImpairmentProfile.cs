using mefit_backend.models.domain;
using mefit_backend.models.DTO.ImpairmentDtos;
using Microsoft.Extensions.Options;

namespace mefit_backend.Profiles
{
    public class ImpairmentProfile : AutoMapper.Profile
    {
        public ImpairmentProfile() 
        {
            CreateMap<PostImpairmentDTO, Impairment>();
            CreateMap<PutImpairmentDTO, Impairment>();
            CreateMap<Impairment, GetImpairmentDTO>();
        }  
           
    }
}
