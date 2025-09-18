using System;
using Microsoft.AspNetCore.Identity;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Domain.Entities.UsersEntities;

public class ApplicationUser : IdentityUser<Guid>
{
    public UserType UserType { get; set; }
    public Guid? RestaurantId { get; set; }
}
