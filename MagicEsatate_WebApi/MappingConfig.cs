using AutoMapper;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;

namespace MagicEsatate_WebApi
{
    public class MappingConfig: Profile
    {

        public MappingConfig()
        {
            CreateMap<Estate, EstateDTO>();
            CreateMap<EstateDTO, Estate>();

            CreateMap<EstateDTO, EstateCreateDTO>().ReverseMap();
            CreateMap<EstateDTO, EstateUpdateDTO>().ReverseMap();
        }
        
    }
}
