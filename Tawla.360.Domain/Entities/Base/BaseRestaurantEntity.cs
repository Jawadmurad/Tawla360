using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Domain.Entities.Base;

public abstract class BaseRestaurantEntity : BaseIdEntity
{
    public Guid RestaurantId { get; set; }
    [ForeignKey(nameof(RestaurantId))]
    public Restaurant Restaurant { get; set; }
}
