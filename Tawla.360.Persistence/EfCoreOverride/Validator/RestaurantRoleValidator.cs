using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Persistence.EfCoreOverride.Validator;

public class RestaurantRoleValidator : RoleValidator<ApplicationRole>
{
    private IdentityErrorDescriber Describer { get; set; } = new IdentityErrorDescriber();
    public override async Task<IdentityResult> ValidateAsync(RoleManager<ApplicationRole> manager, ApplicationRole role)
    {
        ArgumentNullException.ThrowIfNull(manager);
        ArgumentNullException.ThrowIfNull(role);
        var errors = new List<IdentityError>();
        await ValidateRoleName(manager, role, errors);
        if (errors.Count > 0)
        {
            return IdentityResult.Failed(errors.ToArray());
        }
        return IdentityResult.Success;
    }
    private async Task ValidateRoleName(RoleManager<ApplicationRole> manager, ApplicationRole role, ICollection<IdentityError> errors)
    {
        var roleName = await manager.GetRoleNameAsync(role);
        if (string.IsNullOrWhiteSpace(roleName))
        {
            errors.Add(Describer.InvalidRoleName(roleName));
            return;
        }
        var any = await manager.Roles.AnyAsync(c => c.RestaurantId == role.RestaurantId && c.Id != role.Id);
        if (any)
        {
            errors.Add(Describer.DuplicateRoleName(roleName));
        }
    }
}
