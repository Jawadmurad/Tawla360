namespace Tawla._360.Domain.Interfaces.Entities;

public interface IHasRestaurant : IBaseIdEntity
{
    public Guid RestaurantId { get; set; }
}
