using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Entities.UsersEntities;
using Tawla._360.Persistence.DbContexts;

namespace Tawla._360.Persistence.EfCoreOverride.Stores;

public class RestaurantRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, Guid>
{
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    public RestaurantRoleStore(ApplicationDbContext context,IHttpContextAccessorService httpContextAccessorService, IdentityErrorDescriber describer = null) : base(context, describer)
    {
        _httpContextAccessorService = httpContextAccessorService;
    }
    public override IQueryable<ApplicationRole> Roles => base.Roles.Where(c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
    public override Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken = default)
    {
        role.RestaurantId = _httpContextAccessorService.GetRestaurantId();
        return base.CreateAsync(role, cancellationToken);
    }
}
