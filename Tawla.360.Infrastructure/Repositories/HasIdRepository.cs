using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tawla._360.Domain.Interfaces.Entities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Infrastructure.Repositories;

public class HasIdRepository<T>(DbContext context) : Repository<T>(context), IHasIdRepository<T> where T : class, IHasId, new()
{
    public ValueTask<T> Find(Guid id)
    {
        return _dbSet.FindAsync(id);
    }
    public Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        query = IncludeLambda(query, includes);
        return query.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<T> GetByIdAsync(Guid id, string includes)
    {
        var query = _dbSet.AsQueryable();
        if (!string.IsNullOrWhiteSpace(includes))
        {
            query = query.Include(includes);
        }
        return query.FirstOrDefaultAsync(c => c.Id == id);
    }
}
