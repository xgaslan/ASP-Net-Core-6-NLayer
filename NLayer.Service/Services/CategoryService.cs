using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Service.Category;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class CategoryService : Service<Category>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetCategoriesWithProducts()
    {
        var categories = await _categoryRepository.GetCategoriesWithProducts();
        var categoriesMap = _mapper.Map<List<CategoryWithProductsDto>>(categories);
        return CustomResponseDto<List<CategoryWithProductsDto>>.Success(200, categoriesMap);
    }

    public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdWithProducts(id);
        var categoryMap = _mapper.Map<CategoryWithProductsDto>(category);
        return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryMap);
    }
}