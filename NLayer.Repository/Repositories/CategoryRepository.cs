using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetCategoriesWithProducts()
    {
        var result = await _context.Categories
            .Include(c => c.Products).ToListAsync();
        return result;
    }

    public async Task<Category> GetCategoryByIdWithProducts(int id)
    {
        var result = await _context.Categories
            .Include(c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == id);
        return result;
    }
}