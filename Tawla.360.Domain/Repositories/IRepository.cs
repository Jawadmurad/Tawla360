using System.Linq.Expressions;
using Tawla._360.Shared;

namespace Tawla._360.Domain.Repositories;

public interface IRepository<T> where T : class, new()
{
    Task<IReadOnlyList<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includes = null);

    Task<IReadOnlyList<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes);

    Task<IReadOnlyList<T>> GetAllAsNoTrackingAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includes = null);

    Task<IReadOnlyList<T>> GetAllAsNoTrackingAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes);

    Task<PagingResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes);

    Task AddAsync(T entity);
    void Add(T entity);
    Task AddWithSave(T entity);
    Task Reload(T entity);
    Task UpdateAsync(T entity);
    void Delete(T entity);
    Task DeleteWithSaveAsync(T entity);

    Task<IReadOnlyList<TResult>> Select<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);

    Task<TKey> MaxAsync<TKey>(Expression<Func<T, TKey>> selector, Expression<Func<T, bool>> filter = null);
    Task<decimal> SumAsync(Expression<Func<T, decimal>> sumSelector, Expression<Func<T, bool>> filter = null);

    Task<List<TValue>> GroupByAsync<TKey, TValue>(
        Expression<Func<T, TKey>> groupBySelector,
        Expression<Func<IGrouping<TKey, T>, TValue>> projection,
        Expression<Func<T, bool>> filter = null);

    Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includes);

    Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>> filter,
        string includes = null);
    
}
