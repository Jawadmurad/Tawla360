using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Application.ItemUseCases.Dtos.Common;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ItemUseCases;

public class ItemService : HasRestaurantService<Item, CreateItemDto, UpdateItemDto, ItemListDto, ItemDto, LiteItemDto>, IItemService
{
    private readonly IRepository<ItemPrice> _itemPriceRepo;
    public ItemService(IHasIdRepository<Item> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
    public async Task ReplacePricesAsync(Guid itemId, IEnumerable<ItemPriceDto> priceDtos)
    {
        var existingPrices = await _itemPriceRepo.GetAllAsync(x => x.ItemId == itemId);
        if (existingPrices.Any())
        {
            _itemPriceRepo.DeleteRange(existingPrices);
        }
        if (priceDtos?.Any()==true)
        {
            var newPrices = _mapper.Map<List<ItemPrice>>(priceDtos);

            // Ensure links are set correctly
            foreach (var price in newPrices)
            {
                price.ItemId = itemId;
                price.Id = Guid.NewGuid(); // Ensure ID is set
            }

            await _itemPriceRepo.AddRangeAsync(newPrices);
        }
    }
}
