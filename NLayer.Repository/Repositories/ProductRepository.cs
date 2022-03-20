using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository

{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsWithCategory()
    {
        var result = await _context.Products
            .Include(p => p.Category).ToListAsync();
        return result;
    }

    public async Task<Product> GetProductByIdWithCategory(int id)
    {
        var result = await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        return result;
    }
}