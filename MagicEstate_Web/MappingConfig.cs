using AutoMapper;
using MagicEsatate_Web.Models;
using MagicEsatate_Web.Models.Dto;

namespace MagicEsatate_Web
{
    public class MappingConfig: Profile
    {

        public MappingConfig()
        {
           CreateMap<EstateDTO, EstateCreateDTO>().ReverseMap();
           CreateMap<EstateDTO, EstateUpdateDTO>().ReverseMap();

            CreateMap<EstateNumberDTO, EstateNumberCreateDTO>().ReverseMap();
            CreateMap<EstateNumberDTO, EstateNumberUpdateDTO>().ReverseMap();

        }

    }
}
