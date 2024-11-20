using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using FluentValidation;

namespace ENTITY_FRAMEWORK_EXAMPLE.Validators;

public class BrandUpdateValidator : AbstractValidator<BrandUpdateDto>
{
    public BrandUpdateValidator()
    {   
        RuleFor(b => b.Id).NotEmpty().WithMessage("Id obligatorio");
        RuleFor(b => b.Nombre).NotEmpty().WithMessage("Nombre obligatorio");
        RuleFor(b => b.Nombre).Length(2,20).WithMessage("El nombre debe tener mas de 2 a 20 caracteres");
    }
}
