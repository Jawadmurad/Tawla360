using Tawla._360.Domain.Repositories;
using Tawla._360.Persistence.DbContexts;

namespace Tawla._360.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public Task Rollback()
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return _applicationDbContext.SaveChangesAsync();
    }
}
