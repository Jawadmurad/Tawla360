using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.RestaurantEntities;

public class Branch : BaseRestaurantEntity
{
    public int Number { get; set; }
    public string Location { get; set; }
}
