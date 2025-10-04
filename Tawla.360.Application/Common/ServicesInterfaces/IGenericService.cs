using System.Linq.Expressions;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.Common.ServicesInterfaces;

public interface IGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class,new()
    where TCreate : class
    where TUpdate : class
    where TList : class
    where TDetails : class
    where TLite : class
{
    Task<PagingResult<TList>> GetPagedAsync(QueryRequestDto query);
    Task<IReadOnlyList<TList>> GetAllAsync();

    Task<IReadOnlyList<TLite>> GetLiteAsync(Expression<Func<TEntity, bool>> filter = null);

    Task<TDetails> CreateAsync(TCreate createDto);
    Task UpdateAsync(TUpdate updateDto);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

    Task<TKey> MaxAsync<TKey>(Expression<Func<TEntity, TKey>> selector, Expression<Func<TEntity, bool>> filter = null);

    Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> sumSelector, Expression<Func<TEntity, bool>> filter = null);

    Task<List<TValue>> GroupByAsync<TKey, TValue>(
        Expression<Func<TEntity, TKey>> groupBySelector,
        Expression<Func<IGrouping<TKey, TEntity>, TValue>> projection,
        Expression<Func<TEntity, bool>> filter = null);

    Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

    Task<TDetails> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

    Task<TDetails> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, string includes = null);
    Task<IReadOnlyList<DDT>> Select<DDT>(Expression<Func<TEntity, DDT>> projection, Expression<Func<TEntity, bool>> filter = null) where DDT : class, new();
}
