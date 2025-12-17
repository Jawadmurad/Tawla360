using Tawla._360.Application.Attributes;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

namespace Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;

public record class UpdateModifierGroupOptionDto
{
    public Guid? Id { get; set; } // Null if it's a new option
    public Guid? ModifierId { get; set; } // Link to an existing Modifier entity
    [Translatable]
    public string Name { get; set; }
    public int? DisplayOrder { get; set; }
    public List<CreateItemModifierPriceChange> PriceChanges { get; set; }

}
