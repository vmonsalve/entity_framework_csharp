using System;
using AutoMapper;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;

namespace ENTITY_FRAMEWORK_EXAMPLE.Automappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BeerInsertDto, Beer>();
        CreateMap<Beer, BeerDto>()
        .ForMember(dto => dto.Id, m => m.MapFrom(b => b.BeerID));
        CreateMap<BeerUpdateDto, Beer>();

        CreateMap<BrandInsertDto, Brand>();
        CreateMap<Brand, BrandDto>()
        .ForMember(dto => dto.Id, m => m.MapFrom(b => b.BrandID));
        CreateMap<BrandUpdateDto, Brand>();
    }
}
