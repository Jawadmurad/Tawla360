using System.Linq.Expressions;
using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Repositories;
using Tawla._360.Shared;

namespace Tawla._360.Application.Services;

public class GenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : IGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, new()
    where TCreate : class
    where TUpdate : class
    where TList : class
    where TDetails : class
    where TLite : class
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public GenericService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TList>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsNoTrackingAsync();
        return _mapper.Map<IReadOnlyList<TList>>(entities);
    }

    public Task<IReadOnlyList<TLite>> GetLiteAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        var projection = GenerateProjectionExpression<TEntity, TLite>();
        return _repository.Select(projection, filter);
    }
    public Task<IReadOnlyList<DDT>> Select<DDT>(Expression<Func<TEntity, DDT>> projection, Expression<Func<TEntity, bool>> filter = null) where DDT : class, new()
    {
        return _repository.Select(projection, filter);
    }
    public virtual async Task<TDetails> CreateAsync(TCreate createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        await _repository.AddAsync(entity);
        return _mapper.Map<TDetails>(entity);
    }


    public async Task<PagingResult<TList>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null)
    {
        var pagedResult = await _repository.GetPagedAsync(pageNumber, pageSize, filter);
        var mappedItems = _mapper.Map<List<TList>>(pagedResult.Data);
        return new PagingResult<TList>()
        {
            Data = mappedItems,
            Count = pagedResult.Count
        };
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        => _repository.AnyAsync(filter);

    public Task<TKey> MaxAsync<TKey>(Expression<Func<TEntity, TKey>> selector, Expression<Func<TEntity, bool>> filter = null)
        => _repository.MaxAsync(selector, filter);

    public Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> sumSelector, Expression<Func<TEntity, bool>> filter = null)
        => _repository.SumAsync(sumSelector, filter);

    public Task<List<TValue>> GroupByAsync<TKey, TValue>(Expression<Func<TEntity, TKey>> groupBySelector, Expression<Func<IGrouping<TKey, TEntity>, TValue>> projection, Expression<Func<TEntity, bool>> filter = null)
        => _repository.GroupByAsync(groupBySelector, projection, filter);

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        => _repository.CountAsync(filter);

    public async Task<TDetails> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
    {
        var entity = await _repository.FirstOrDefaultAsync(filter, includes);
        return _mapper.Map<TDetails>(entity);
    }

    public async Task<TDetails> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, string includes = null)
    {
        var entity = await _repository.FirstOrDefaultAsync(filter, includes);
        return _mapper.Map<TDetails>(entity);
    }
    protected static Expression<Func<Entity, Projection>> GenerateProjectionExpression<Entity, Projection>()
    where Entity : class
    where Projection : class
    {
        var parameter = Expression.Parameter(typeof(TEntity), "e");
        var bindings = typeof(TLite)
            .GetProperties()
            .Where(p => p.CanWrite)
            .Select(p =>
            {
                var sourceProp = typeof(TEntity).GetProperty(p.Name);
                if (sourceProp == null) return null;

                var propertyAccess = Expression.Property(parameter, sourceProp);
                return Expression.Bind(p, propertyAccess);
            })
            .Where(b => b != null);

        var body = Expression.MemberInit(Expression.New(typeof(TLite)), bindings);
        return Expression.Lambda<Func<Entity, Projection>>(body, parameter);
    }

    public async Task UpdateAsync(TUpdate updateDto)
    {
        var entity = _mapper.Map<TEntity>(updateDto);
        await _repository.UpdateAsync(entity);
    }
}