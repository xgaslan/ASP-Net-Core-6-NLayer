using AutoMapper;
using NLayer.Core.DTOs.Controller.Create;
using NLayer.Core.DTOs.Controller.Update;
using NLayer.Core.DTOs.Service.Category;
using NLayer.Core.DTOs.Service.Product;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryWithProductsDto>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<CategoryCreateDto, Category>();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductWithCategoryDto>();

    }
}