﻿using FluentValidation;
using NLayer.Core.DTOs.Service.Product;

namespace NLayer.Service.Validations;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
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