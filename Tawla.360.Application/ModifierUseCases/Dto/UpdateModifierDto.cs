using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.ModifierUseCases.Dto;

public record UpdateModifierDto:IHasId
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }
}
