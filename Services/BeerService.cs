using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
{
    private StoreContext _context;
    public BeerService(StoreContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<BeerDto>> Get() => 
        await _context.Beers.Select(b => new BeerDto{
            Id = b.BeerID,
            Nombre = b.Nombre,
            Alcohol = b.Alcohol,
            BrandID = b.BrandID
        }).ToListAsync();

    public async Task<BeerDto> GetById(int id)
    {
        var beer = await _context.Beers.FindAsync(id);
        if (beer != null)
        {
            var beerDto = new BeerDto{
                Id = beer.BeerID,
                Nombre = beer.Nombre,
                BrandID = beer.BrandID,
                Alcohol = beer.Alcohol 

            };
            return beerDto;
        }
        return null;
        
    }

    public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
    {
        var beer = new Beer{
            Nombre = beerInsertDto.Nombre,
            BrandID = beerInsertDto.BrandID,    
            Alcohol = beerInsertDto.Alcohol
        };

        await _context.Beers.AddAsync(beer);
        await _context.SaveChangesAsync();

        var  beerDto = new BeerDto{
            Id = beer.BeerID,
            Nombre = beer.Nombre,
            BrandID = beer.BrandID,
            Alcohol = beer.Alcohol
        };

        return beerDto;
    }

    public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
    {
        var beer = await _context.Beers.FindAsync(id);
        
        if (beer != null){
            beer.Nombre = beerUpdateDto.Nombre;
            beer.BrandID = beer.BrandID;
            beer.Alcohol = beerUpdateDto.Alcohol;

            await _context.SaveChangesAsync();

            var  beerDto = new BeerDto{
                Id = beer.BeerID,
                Nombre = beer.Nombre,
                BrandID = beer.BrandID,
                Alcohol = beer.Alcohol
            };

            return beerDto;
        }

        return null;
    }
    
    public async Task<BeerDto> Delete(int id)
    {

        var beer = await _context.Beers.FindAsync(id);

        if (beer != null){

            var  beerDto = new BeerDto{
                Id = beer.BeerID,
                Nombre = beer.Nombre,
                BrandID = beer.BrandID,
                Alcohol = beer.Alcohol
            };

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            return beerDto;
        }

        return null;
    }

}
