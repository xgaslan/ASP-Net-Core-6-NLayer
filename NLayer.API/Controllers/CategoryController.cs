using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Controller.Create;
using NLayer.Core.DTOs.Controller.Update;
using NLayer.Core.DTOs.Service.Category;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        #region Definition

        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        #endregion

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        #region Create
        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var categoryMap = _mapper.Map<Category>(categoryCreateDto);
            var category = await _categoryService.AddAsync(categoryMap);
            var categoryDtoMap = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDtoMap));
        }
        #endregion

        #region Read
        #region Get All
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesMap = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesMap));
        }
        #endregion

        #region Get Category By Id
        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));
        }
        #endregion

        #region Get Categories With Products
        [HttpGet("get-categories-with-products")]
        public async Task<IActionResult> GetCategoriesWithProducts()
        {
            var result = await _categoryService.GetCategoriesWithProducts();
            return CreateActionResult(result);
        }
        #endregion 

        #region Get Category By Id With Products
        [HttpGet("get-category-by-id-with-products/{id}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int id)
        {
            var result = await _categoryService.GetCategoryByIdWithProducts(id);
            return CreateActionResult(result);
        }
        #endregion 

        #endregion

        #region Update
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto, int id)
        {
            var categoryMap = _mapper.Map<Category>(categoryUpdateDto);
            categoryMap.Id = id;
            await _categoryService.UpdateAsync(categoryMap);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion

        #region Delete
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            await _categoryService.DeleteAsync(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
