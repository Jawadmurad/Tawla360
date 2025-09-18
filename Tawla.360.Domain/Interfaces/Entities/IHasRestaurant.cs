namespace Tawla._360.Domain.Interfaces.Entities;

public interface IHasRestaurant : IHasId
{
    public Guid RestaurantId { get; set; }
}
