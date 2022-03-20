using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Controller.Create;
using NLayer.Core.DTOs.Controller.Update;
using NLayer.Core.DTOs.Service.Product;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        #region Definitions
        private readonly IMapper _mapper;
        private readonly IProductService _productService; 
        #endregion

        #region Constructor
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        } 
        #endregion

        #region Create
        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var productMap = _mapper.Map<Product>(productCreateDto);
            var product = await _productService.AddAsync(productMap);
            var productDtoMap = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDtoMap));
        }
        #endregion

        #region Read
        #region Get All
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }
        #endregion

        #region Get Product By Id
        [HttpGet("get-product-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }
        #endregion

        #region Get Products With Category
        [HttpGet("get-products-with-category")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var result = await _productService.GetProductsWithCategory();
            return CreateActionResult(result);
        }
        #endregion 

        #region Get Product By Id With Category
        [HttpGet("get-product-by-id-with-category/{id}")]
        public async Task<IActionResult> GetProductByIdWithCategory(int id)
        {
            var result = await _productService.GetProductByIdWithCategory(id);
            return CreateActionResult(result);
        }
        #endregion 
        #endregion

        #region Update
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto, int id)
        {
            var productMap = _mapper.Map<Product>(productUpdateDto);
            productMap.Id = id;
            await _productService.UpdateAsync(productMap);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion

        #region Delete
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        } 
        #endregion
    }
}
