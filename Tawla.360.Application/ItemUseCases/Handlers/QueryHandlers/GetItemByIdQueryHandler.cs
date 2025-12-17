using System;
using MediatR;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Application.ItemUseCases.Query;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Exceptions;

namespace Tawla._360.Application.ItemUseCases.Handlers.QueryHandlers;

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemDto>
{
    private readonly IItemService _itemService;
    public GetItemByIdQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }
    public async Task<ItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var includes = Item.GetIncludeForDetails();
        var result = await _itemService.FirstOrDefaultAsync(x => x.Id == request.Id, includes) ?? throw new NotFoundException($"Item with ID {request.Id} not found.");
        return result;

    }
}
