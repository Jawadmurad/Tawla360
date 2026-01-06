using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.ModifierGroupUserCase.Dtos;

public record ModifierGroupDto
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public List<ModifierOptionDto> Options { get; set; }

}
