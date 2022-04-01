using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;

namespace NLayer.Service.Services;

public class Service<T> : IService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        var result = entity;
        return result;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _repository.AddRangeAsync(entities);
        await _unitOfWork.CommitAsync();
        var result = entities;
        return result;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {

        return await _repository.AnyAsync(filter);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _repository.GetAll().ToListAsync();
        return result;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            throw new NotFoundException($"{typeof(T).Name}({id}) not found");
        }
        return result;
    }

    public async Task DeleteAsync(T entity)
    {
        _repository.Delete(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _repository.DeleteRange(entities);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> filter)
    {
        var result = _repository.Where(filter);
        return result;
    }


}