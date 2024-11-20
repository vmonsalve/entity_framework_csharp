using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator;

        public BeerController(
            StoreContext context, 
            IValidator<BeerInsertDto> beerInsertValidator,
            IValidator<BeerUpdateDto> beerUpdateValidator
            )
        {
            _context = context;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() => 
           await _context.Beers.Select(b => new BeerDto{
                Id = b.BeerID,
                Nombre = b.Nombre,
                Alcohol = b.Alcohol,
                BrandID = b.BrandID
            }).ToListAsync();
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null) return NotFound();
            
            var beerDto = new BeerDto{
                Id = beer.BeerID,
                Nombre = beer.Nombre,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };
            return Ok(beerDto);
        }
        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);

            if (!validationResult.IsValid){
                return BadRequest(validationResult.Errors); 
            }

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

            return CreatedAtAction(nameof(GetById), new {id = beer.BeerID}, beerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto){
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors); 
            
            var beer = await _context.Beers.FindAsync(id);
            if(beer == null) return NotFound();
            

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

            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            var beer = await _context.Beers.FindAsync(id);

            if(beer == null){
                return NotFound();
            }

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            return Ok();

        }

    } 
}
