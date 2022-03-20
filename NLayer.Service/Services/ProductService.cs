using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Service.Product;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class ProductService : Service<Product>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
    {
        var products = await _productRepository.GetProductsWithCategory();
        var productsMap = _mapper.Map<List<ProductWithCategoryDto>>(products);
        return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsMap);
    }

    public async Task<CustomResponseDto<ProductWithCategoryDto>> GetProductByIdWithCategory(int id)
    {
        var product = await _productRepository.GetProductByIdWithCategory(id);
        var productMap = _mapper.Map<ProductWithCategoryDto>(product);
        return CustomResponseDto<ProductWithCategoryDto>.Success(200, productMap);
    }
}