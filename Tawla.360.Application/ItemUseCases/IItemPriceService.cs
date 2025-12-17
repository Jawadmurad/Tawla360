using System;
using Tawla._360.Application.ItemUseCases.Dtos.Common;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

namespace Tawla._360.Application.ItemUseCases;

public interface IItemPriceService
{
    Task ReplacePricesAsync(Guid itemId, IEnumerable<ItemPriceDto> priceDtos);

}
