using System;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using AutoMapper;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using ENTITY_FRAMEWORK_EXAMPLE.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public class BrandService : ICommonService<BrandDto, BrandInsertDto, BrandUpdateDto>
{
    private IRepository<Brand> _brandRepository;
    private IMapper _mapper;
    public List<string> Errors { get; }

    public BrandService(IRepository<Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        Errors = new List<string>();
    }

    public async Task<IEnumerable<BrandDto>> Get()
    {
        var brands = await _brandRepository.Get();
        return brands.Select(b => _mapper.Map<BrandDto>(b));
    }
    

    public async Task<BrandDto> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand != null) return _mapper.Map<BrandDto>(brand);            
        return null;
    }

    public async Task<BrandDto> Add(BrandInsertDto brandInsertDto)
    {
        var brand = _mapper.Map<Brand>(brandInsertDto);

        await _brandRepository.Add(brand);
        await _brandRepository.Save();

        return  _mapper.Map<BrandDto>(brand);
    }

    public async Task<BrandDto> Update(int id, BrandUpdateDto brandUpdateDto)
    {
        var brand = await _brandRepository.GetById(id);
        if(brand != null)
        {
            _mapper.Map<BrandUpdateDto, Brand>(brandUpdateDto, brand);

            _brandRepository.Update(brand);
            await _brandRepository.Save();

            return _mapper.Map<BrandDto>(brand);
        }

        return null;
    }

    public async Task<BrandDto> Delete(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand != null)
        {
            var brandDto =  _mapper.Map<BrandDto>(brand);
            _brandRepository.Delete(brand);
            await _brandRepository.Save();

            return brandDto;
        }

        return null;
    }

    public bool Validate(BrandInsertDto brandInsertDto)
    {
        if (_brandRepository.Search(b => b.Nombre == brandInsertDto.Nombre).Count() > 0)
        {
            Errors.Add("La marca ya existe");
            return false;
        }
        return true;
    }

    public bool Validate(BrandUpdateDto  brandUpdateDto)
    {
        if (_brandRepository.Search(b => b.Nombre == brandUpdateDto.Nombre && brandUpdateDto.Id == b.BrandID).Count() > 0)
        {
            Errors.Add("La Marca ya existe");
            return false;
        }
        return true;
    }


}
