using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.ModifierUseCases.Dto;

public record CreateModifierDto
{
    [Translatable]
    public string Name { get; set; }
}
