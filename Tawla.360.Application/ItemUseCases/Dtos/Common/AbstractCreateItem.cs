using Tawla._360.Application.Attributes;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

namespace Tawla._360.Application.ItemUseCases.Dtos.Common;

public abstract record AbstractCreateItem:AbstractItemManipulation
{

    public List<CreateItemModifierGroupDto> ModifierGroups { get; set; }

}
