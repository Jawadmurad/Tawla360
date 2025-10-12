using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.UsersEntities;

public class UserBranch:IHasId
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BranchId { get; set; }
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; }
    [ForeignKey(nameof(BranchId))]
    public Branch Branch { get; set; }
}
