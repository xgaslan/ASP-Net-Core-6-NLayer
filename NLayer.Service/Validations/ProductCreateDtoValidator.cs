using FluentValidation;
using NLayer.Core.DTOs.Controller.Create;

namespace NLayer.Service.Validations;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(x => x.Price)
            .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater then 0");

        RuleFor(x => x.Stock)
            .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater then 0");

        RuleFor(x => x.CategoryId)
            .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater then 0");
    }
    
}