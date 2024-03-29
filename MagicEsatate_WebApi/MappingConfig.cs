﻿using AutoMapper;
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

            CreateMap<Estate, EstateCreateDTO>().ReverseMap();
            CreateMap<Estate, EstateUpdateDTO>().ReverseMap();

            CreateMap<EstateNumber, EstateNumberDTO>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberCreateDTO>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberUpdateDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();

        }

    }
}
