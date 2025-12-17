using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.ModifierUseCases.Dto;

public record class ModifierListDto
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }
}
