using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.UsersEntities;

public class ApplicationUser : IdentityUser<Guid>, IBaseIdEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }
    public Guid? RestaurantId { get; set; }
    [ForeignKey(nameof(RestaurantId))]
    public Restaurant Restaurant { get; set; }
    public DateTime CreatedDate {get;set;}
    public string CreatedBy {get;set;}
    public DateTime? ModifiedDate {get;set;}
    public string ModifiedBy {get;set;}
    public ICollection<UserBranch> UserBranches { get; set; }
}
