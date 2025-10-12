using System;
using Tawla._360.Domain.Entities.UsersEntities;
using Tawla._360.Domain.Repositories.UserRepositories;
using Tawla._360.Persistence.DbContexts;

namespace Tawla._360.Infrastructure.Repositories.UserRepositories;

internal class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationDbContext context) : base(context)
    {
    }
}
