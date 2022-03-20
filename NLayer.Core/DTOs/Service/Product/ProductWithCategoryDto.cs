using NLayer.Core.DTOs.Service.Category;

namespace NLayer.Core.DTOs.Service.Product;

public class ProductWithCategoryDto : ProductDto
{
    public CategoryDto Category { get; set; }
}