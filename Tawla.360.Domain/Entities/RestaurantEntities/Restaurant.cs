using System;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.RestaurantEntities;

public class Restaurant : BaseNamedEntity
{
    public string Description { get; set; }
    public string Logo { get; set; }
    public bool IsActive { get; set; }
}
