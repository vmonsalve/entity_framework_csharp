using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public class BrandService : ICommonService<BrandDto, BrandInsertDto, BrandUpdateDto>
{
    private StoreContext _context;

    public BrandService(StoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BrandDto>> Get()  => 
        await _context.Brands.Select(b => new BrandDto{
                Id = b.BrandID,
                Nombre = b.Nombre
        }).ToListAsync();
    

    public async Task<BrandDto> GetById(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand != null)
        {
            var brandDto = new BrandDto{
                Id = brand.BrandID,
                Nombre = brand.Nombre
            };

            return brandDto;            
        }
        return null;
    }

    public async Task<BrandDto> Add(BrandInsertDto brandInsertDto)
    {
        var brand = new Brand{
            Nombre = brandInsertDto.Nombre,
        };

        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();

        var brandDto = new BrandDto{
            Id = brand.BrandID,
            Nombre = brand.Nombre
        };

        return brandDto;
    }

    public async Task<BrandDto> Update(int id, BrandUpdateDto brandUpdateDto)
    {
        var brand = await _context.Brands.FindAsync(id);
        if(brand != null)
        {
            brand.Nombre = brandUpdateDto.Nombre;

            await _context.SaveChangesAsync();

            var brandDto = new BrandDto{
                Id = brand.BrandID,
                Nombre = brand.Nombre
            };

            return brandDto;
        }

        return null;
    }

    public async Task<BrandDto> Delete(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand != null)
        {
            var brandDto = new BrandDto{
                Id = brand.BrandID,
                Nombre = brand.Nombre
            };

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return brandDto;
        }

        return null;
    }

}
