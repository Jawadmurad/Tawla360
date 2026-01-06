using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class Item : BaseRestaurantEntity, ITranslatedEntity<ItemTranslation>
{
    public int? LowStockAlert { get; set; }
    public string ImagePath { get; set; }
    public string[] Tags { get; set; }
    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    public ICollection<ItemTranslation> Translations { get; set; }
    public ICollection<ItemPrice> Prices { get; set; }
    public ICollection<ModifierGroup> ModifierGroups { get; set; }
        public static string GetIncludeForDetails()
    {
        var includes = new List<string>
        {
            nameof(Category),
            nameof(Prices),
            // Path: ModifierGroups -> Options -> Modifier
            $"{nameof(ModifierGroups)}.{nameof(ModifierGroup.Options)}.{nameof(ModifierOption.Modifier)}",
            // Path: ModifierGroups -> Options -> Prices
            $"{nameof(ModifierGroups)}.{nameof(ModifierGroup.Options)}.{nameof(ModifierOption.ModifierOptionPrices)}"
        };

        return string.Join(",", includes);
    }

}
