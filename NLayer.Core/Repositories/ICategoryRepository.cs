using NLayer.Core.Models;

namespace NLayer.Core.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<List<Category>> GetCategoriesWithProducts();
    Task<Category> GetCategoryByIdWithProducts(int id);
}