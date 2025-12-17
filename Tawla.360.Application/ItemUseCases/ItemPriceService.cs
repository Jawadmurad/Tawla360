using AutoMapper;
using Tawla._360.Application.ItemUseCases.Dtos.Common;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ItemUseCases;

public class ItemPriceService : IItemPriceService
{
    private readonly IRepository<ItemPrice> _repository; // Or your specific DbContext
    private readonly IMapper _mapper;

    public ItemPriceService(IRepository<ItemPrice> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task ReplacePricesAsync(Guid itemId, IEnumerable<ItemPriceDto> priceDtos)
    {
        // 1. Remove existing prices for this item
        // If using EF Core 7+, this is the most performant way:
        // await _context.ItemPrices.Where(x => x.ItemId == itemId).ExecuteDeleteAsync();

        // Standard Repository approach:
        var existingPrices = await _repository.GetAllAsync(x => x.ItemId == itemId);
        if (existingPrices.Any())
        {
            _repository.DeleteRange(existingPrices);
        }

        // 2. Add new prices
        if (priceDtos != null && priceDtos.Any())
        {
            var newPrices = _mapper.Map<List<ItemPrice>>(priceDtos);

            // Ensure links are set correctly
            foreach (var price in newPrices)
            {
                price.ItemId = itemId;
                price.Id = Guid.NewGuid(); // Ensure ID is set
            }

            await _repository.AddRangeAsync(newPrices);
        }
    }
}
