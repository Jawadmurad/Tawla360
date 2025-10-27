using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tawla._360.Domain.Repositories;
using Tawla._360.Infrastructure.Extensions;
using Tawla._360.Persistence.DbContexts;
using Tawla._360.Shared;

namespace Tawla._360.Infrastructure.Repositories;

internal class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class, new()
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task Reload(T entity)
    {
        return _context.Entry(entity).ReloadAsync();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);

    }
    public Task DeleteWithSaveAsync(T entity)
    {
        _dbSet.Remove(entity);
        return _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    string includes = null)
    {
        var query = _dbSet.AsQueryable();
        if (!string.IsNullOrWhiteSpace(includes))
        {
            query = query.Include(includes);
        }
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        query = IncludeLambda(query, includes);
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsNoTrackingAsync(Expression<Func<T, bool>> filter = null,
                                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                string includes = null)
    {
        var query = _dbSet.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(includes))
        {
            query = query.Include(includes);
        }
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsNoTrackingAsync(Expression<Func<T, bool>> filter = null,
                                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                params Expression<Func<T, object>>[] includes)
    {
        var query = _dbSet.AsNoTracking();
        query = IncludeLambda(query, includes);
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<PagingResult<T>> GetPagedAsync(int pageNumber, int pageSize,
                                                     Expression<Func<T, bool>> filter = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                     params Expression<Func<T, object>>[] includes)
    {
        var query = _dbSet.AsNoTracking();
        query = IncludeLambda(query, includes);
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) query = orderBy(query);

        var count = await query.CountAsync();
        var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagingResult<T> { Data = data, Count = count };
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    protected IQueryable<T> IncludeLambda(IQueryable<T> query, params Expression<Func<T, object>>[] propertySelectors)
    {
        if (propertySelectors != null)
        {
            foreach (var item in propertySelectors)
            {
                var path = item.AsPath();
                if (!string.IsNullOrWhiteSpace(path))
                    query = query.Include(path);
            }
        }
        return query;
    }
    public async Task<IReadOnlyList<TResult>> Select<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return await query.AsNoTracking().Select(selector).ToListAsync();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {
        return _dbSet.AsNoTracking().AnyAsync(filter);
    }

    public Task<TKey> MaxAsync<TKey>(Expression<Func<T, TKey>> selector, Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
            query = query.Where(filter);
        return query.AsNoTracking().MaxAsync(selector);
    }

    public Task<decimal> SumAsync(Expression<Func<T, decimal>> sumSelector, Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
            query = query.Where(filter);
        return query.AsNoTracking().SumAsync(sumSelector);
    }

    public async Task<List<TValue>> GroupByAsync<TKey, TValue>(
        Expression<Func<T, TKey>> groupBySelector,
        Expression<Func<IGrouping<TKey, T>, TValue>> projection,
        Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
            query = query.Where(filter);
        return await query.AsNoTracking().GroupBy(groupBySelector).Select(projection).ToListAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
            query = query.Where(filter);
        return await query.CountAsync();
    }
    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.FirstOrDefaultAsync(filter);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (!string.IsNullOrWhiteSpace(includes))
        {
            foreach (var include in includes.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                query = query.Include(include);
            }
        }

        return await query.FirstOrDefaultAsync(filter);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddWithSave(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    
}
