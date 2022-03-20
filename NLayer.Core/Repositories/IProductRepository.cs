using NLayer.Core.Models;

namespace NLayer.Core.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithCategory();
    Task<Product> GetProductByIdWithCategory(int id);
}