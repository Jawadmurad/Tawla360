using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Domain.Entities.RestaurantEntities;

public class Branch : BaseRestaurantEntity
{
    public int Number { get; set; }
    public string Location { get; set; }
}
