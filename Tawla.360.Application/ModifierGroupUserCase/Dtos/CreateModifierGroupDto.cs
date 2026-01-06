using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.ModifierGroupUserCase.Dtos;

public record class CreateModifierGroupDto
{
    [Translatable]
    public string Name { get; set; }
    public bool MultipleQuantity { get; set; }
    public decimal? MaxMultipleQuantity { get; set; }
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public Guid ItemId { get; set; }
    public List<CreateModifierGroupOptionDto> Options { get; set; }
}
