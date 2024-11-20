using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using FluentValidation;

namespace ENTITY_FRAMEWORK_EXAMPLE.Validators;

public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
{
    public BeerInsertValidator(){
        RuleFor(b => b.Nombre).NotEmpty().WithMessage("Nombre obligatorio");
        RuleFor(b => b.Nombre).Length(2,20).WithMessage("El nombre debe tener mas de 2 a 20 caracteres");
        RuleFor(b => b.BrandID).NotNull().WithMessage("Marca obligatoria");
        RuleFor(b => b.BrandID).GreaterThan(0).WithMessage("Marca invalida");
        RuleFor(b => b.Alcohol).GreaterThan(0).WithMessage("El {PropertyName} debe ser mayor a cero");
    }
}
