using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ModifierUseCases;

public interface IModifierService: IHasIdGenericService<Modifier,CreateModifierDto,UpdateModifierDto,ModifierListDto,ModifierDto,ModifierLiteDto>
{
}
