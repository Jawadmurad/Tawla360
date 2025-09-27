using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.UsersEntities;

public class ApplicationUser : IdentityUser<Guid>, IHasId
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }
    public Guid? RestaurantId { get; set; }
    [ForeignKey(nameof(RestaurantId))]
    public Restaurant Restaurant { get; set; }
}
