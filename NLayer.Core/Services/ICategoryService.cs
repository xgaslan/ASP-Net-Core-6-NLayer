 using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Service.Category;
using NLayer.Core.Models;

namespace NLayer.Core.Services;

public interface ICategoryService : IService<Category>
{
    Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetCategoriesWithProducts();
    Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int id);

}