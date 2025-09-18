using System.Linq.Expressions;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Repositories;

public interface IHasIdRepository<T> : IRepository<T> where T : class, IHasId, new()
{
    ValueTask<T> Find(Guid id);
    Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdAsync(Guid id, string includes);
}
