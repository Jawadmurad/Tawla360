using Tawla._360.Domain.Repositories;
using Tawla._360.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Tawla._360.Infrastructure.Repositories;


internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task BeginTransactionAsync()
    {
        if (_transaction != null)
            return; // Transaction already started

        _transaction = await _applicationDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction == null)
            throw new InvalidOperationException("No active transaction to commit.");

        try
        {
            await _applicationDbContext.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await Rollback();
            throw;
        }
        finally
        {
            await DisposeTransaction();
        }
    }

    public async Task Rollback()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await DisposeTransaction();
        }
    }

    public Task SaveChangesAsync()
    {
        return _applicationDbContext.SaveChangesAsync();
    }

    private async Task DisposeTransaction()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
