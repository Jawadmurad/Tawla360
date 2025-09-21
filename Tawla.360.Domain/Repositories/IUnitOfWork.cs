namespace Tawla._360.Domain.Repositories;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task SaveChangesAsync();
    Task CommitAsync();
    Task Rollback();
}
