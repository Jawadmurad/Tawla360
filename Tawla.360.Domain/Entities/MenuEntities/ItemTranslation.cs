using System;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class ItemTranslation:Translation
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
}
