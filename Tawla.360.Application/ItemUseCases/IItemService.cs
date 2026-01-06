using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Application.ItemUseCases.Dtos.Common;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ItemUseCases;

public interface IItemService : IHasRestaurantService<Item, CreateItemDto, UpdateItemDto, ItemListDto, ItemDto, LiteItemDto>
{

    Task ReplacePricesAsync(Guid itemId, IEnumerable<ItemPriceDto> priceDtos);
}
