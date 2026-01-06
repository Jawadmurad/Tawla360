using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Base;

public abstract class BaseRestaurantEntity : BaseIdEntity,IHasRestaurant
{
    public Guid RestaurantId { get; set; }
    [ForeignKey(nameof(RestaurantId))]
    public Restaurant Restaurant { get; set; }
}
