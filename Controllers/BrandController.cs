using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ENTITY_FRAMEWORK_EXAMPLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IValidator<BrandInsertDto> _brandInsertValidator;
        private IValidator<BrandUpdateDto> _brandUpdateValidator;
        private ICommonService<BrandDto, BrandInsertDto, BrandUpdateDto> _brandService;

        public BrandController(IValidator<BrandInsertDto> brandInsertValidator,
            IValidator<BrandUpdateDto> brandUpdateValidator,
            ICommonService<BrandDto, BrandInsertDto, BrandUpdateDto> brandService)
        {
            _brandInsertValidator = brandInsertValidator;
            _brandUpdateValidator = brandUpdateValidator;
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IEnumerable<BrandDto>> Get() => 
            await _brandService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(int id)
        {
            var brandDto = await _brandService.GetById(id);
            return brandDto == null ? NotFound() : Ok(brandDto);
        }

        [HttpPost]
        public async Task<ActionResult<BrandDto>> Add(BrandInsertDto brandInsertDto)
        {
            var validationResult = await _brandInsertValidator.ValidateAsync(brandInsertDto);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors); 
            
            var brandDto = await _brandService.Add(brandInsertDto);

            return CreatedAtAction(nameof(GetById), new {id = brandDto.Id}, brandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BrandDto>> Update(int id, BrandUpdateDto brandUpdateDto)
        {
            var validationResult = await _brandUpdateValidator.ValidateAsync(brandUpdateDto);
            if (!validationResult.IsValid)  return BadRequest(validationResult.Errors); 

            var brandDto = _brandService.Update(id, brandUpdateDto);
            
            return brandDto == null ? NotFound() : Ok(brandDto);
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<BrandDto>> Delete(int id)
        {
            var brandDto = await _brandService.Delete(id);
            return brandDto == null ? NotFound() : Ok(brandDto);
        }
    }
}
