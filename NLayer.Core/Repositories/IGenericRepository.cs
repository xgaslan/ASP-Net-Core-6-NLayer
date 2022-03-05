using System.Linq.Expressions;

namespace NLayer.Core.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
    IQueryable<T> Where(Expression<Func<T, bool>> filter);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    void Update(T entity);
    void Delete(int id);
    void DeleteRange(IEnumerable<T> entities);
}