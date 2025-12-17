using Tawla._360.Application.Attributes;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

namespace Tawla._360.Application.ModifierGroupUserCase.Dtos;

public record class CreateModifierGroupOptionDto
{
    public Guid? ModifierId { get; set; }
    [Translatable]
    public string Name { get; set; }
    public int? DisplayOrder { get; set; }
    public List<CreateItemModifierPriceChange> PriceChanges { get; set; }
}
