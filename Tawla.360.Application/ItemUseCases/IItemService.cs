using System;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ItemUseCases;

public interface IItemService:IHasRestaurantService<Item,CreateItemDto,UpdateItemDto,ItemListDto,ItemDto,LiteItemDto>
{

}
