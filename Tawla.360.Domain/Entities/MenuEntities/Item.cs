using System;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class Item:BaseRestaurantEntity,ITranslatedEntity<ItemTranslation>
{
    public Guid CategoryId { get; set; }
    public ICollection<ItemTranslation> Translations { get; set; }
}
