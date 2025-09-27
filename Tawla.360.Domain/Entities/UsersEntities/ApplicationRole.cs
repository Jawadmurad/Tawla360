using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Domain.Entities.UsersEntities;

public class ApplicationRole : IdentityRole<Guid>
{
    public string[] Permissions { get; set; }
    public Guid? RestaurantId { get; set; }
    [ForeignKey(nameof(RestaurantId))]
    public Restaurant Restaurant { get; set; }
}
