using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.ModifierGroupUserCase.Dtos;

public record class UpdateModifierGroupDto : IHasId
{
    public Guid Id {get;set;}
}
