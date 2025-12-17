using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ModifierGroupUserCase;

public interface IModifierGroupService : IHasIdGenericService<ModifierGroup, CreateModifierGroupDto, UpdateModifierGroupDto, ModifierGroupListDto, ModifierGroupListDto, ModifierGroupListDto>
{
}
