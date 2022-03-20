using NLayer.Core.DTOs.Service.Product;

namespace NLayer.Core.DTOs.Service.Category;

public class CategoryWithProductsDto : CategoryDto
{
    public List<ProductDto> Products  { get; set; }
}