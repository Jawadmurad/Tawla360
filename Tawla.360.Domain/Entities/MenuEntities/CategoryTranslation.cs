using System;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class CategoryTranslation:Translation
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
