using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.ItemUseCases.Dtos.Common;

public abstract record AbstractUpdateItem:AbstractItemManipulation,IHasId
{
    
    public Guid Id {get;set;}
    public List<UpdateItemModifierGroupDto> ModifierGroups { get; set; }
}
