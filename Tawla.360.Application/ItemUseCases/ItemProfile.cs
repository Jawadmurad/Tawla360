using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ItemUseCases;

public class ItemProfile:MappingProfile<Item,CreateItemDto,UpdateItemDto,ItemListDto,ItemDto,ItemListDto>
{
}
