using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class Category : BaseRestaurantEntity, ITranslatedEntity<CategoryTranslation>,IHasRestaurant
{
    public string HexColor { get; set; }
    public Guid? ParentCategoryId { get; set; }
    [ForeignKey(nameof(ParentCategoryId))]
    public Category ParentCategory { get; set; }
    public ICollection<CategoryTranslation> Translations { get; set; }
}
