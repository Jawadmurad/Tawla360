using System;
using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ItemUseCases;

public class ItemService : HasRestaurantService<Item, CreateItemDto, UpdateItemDto, ItemListDto, ItemDto, LiteItemDto>, IItemService
{
    public ItemService(IHasIdRepository<Item> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
