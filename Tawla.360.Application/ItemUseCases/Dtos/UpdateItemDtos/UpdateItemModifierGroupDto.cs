using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;

public record UpdateItemModifierGroupDto
{
    public Guid? Id { get; set; } 
    [Translatable]
    public string Name { get; set; }
    public bool MultipleQuantity { get; set; }
    public decimal? MaxMultipleQuantity { get; set; }
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public List<UpdateModifierGroupOptionDto> Options { get; set; }

}
