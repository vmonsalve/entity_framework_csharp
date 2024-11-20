using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using ENTITY_FRAMEWORK_EXAMPLE.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ENTITY_FRAMEWORK_EXAMPLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private StoreContext _context;
        private IValidator<BrandInsertDto> _brandInsertValidator;
        private IValidator<BrandUpdateDto> _brandUpdateValidator;

        public BrandController(
            StoreContext context,
            IValidator<BrandInsertDto> brandInsertValidator,
            IValidator<BrandUpdateDto> brandUpdateValidator
        )
        {
            _context = context;
            _brandInsertValidator = brandInsertValidator;
            _brandUpdateValidator = brandUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BrandDto>> Get() => 
            await _context.Brands.Select(b => new BrandDto{
                Id = b.BrandID,
                Nombre = b.Nombre
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(int id){

            var brand = await _context.Brands.FindAsync(id);

            if(brand==null) return NotFound();

            var brandDto = new BrandDto{
                Id = brand.BrandID,
                Nombre = brand.Nombre
            };
            return Ok(brandDto);   
        }

        [HttpPost]
        public async Task<ActionResult<BrandDto>> Add(BrandInsertDto brandInsertDto)
        {
            var validationResult = await _brandInsertValidator.ValidateAsync(brandInsertDto);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors); 
            
            var brand = new Brand{
                Nombre = brandInsertDto.Nombre,
            };

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            var brandDto = new BrandDto{
                Id = brand.BrandID,
                Nombre = brand.Nombre
            };

            return CreatedAtAction(nameof(GetById), new {id = brand.BrandID}, brandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BrandDto>> Update(int id, BrandUpdateDto brandUpdateDto)
        {

            var validationResult = await _brandUpdateValidator.ValidateAsync(brandUpdateDto);
            if (!validationResult.IsValid)  return BadRequest(validationResult.Errors); 

            var brand = await _context.Brands.FindAsync(id);
            if (brand==null) return NotFound();
            
            brand.Nombre = brandUpdateDto.Nombre;

            await _context.SaveChangesAsync();

            var brandDto = new BrandDto{
                Id = brand.BrandID,
                Nombre = brand.Nombre
            };

            return Ok(brandDto);
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null) return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

           return Ok();
        }
    }
}
