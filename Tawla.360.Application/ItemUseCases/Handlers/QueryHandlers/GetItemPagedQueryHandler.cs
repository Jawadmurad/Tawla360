using System;
using MediatR;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Application.ItemUseCases.Query;
using Tawla._360.Shared;

namespace Tawla._360.Application.ItemUseCases.Handlers.QueryHandlers;

public class GetItemPagedQueryHandler : IRequestHandler<GetItemPagedQuery, PagingResult<ItemListDto>>
{
    private readonly IItemService _itemService;
    public GetItemPagedQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }
    public Task<PagingResult<ItemListDto>> Handle(GetItemPagedQuery request, CancellationToken cancellationToken)
    {
        return _itemService.GetPagedAsync(request.Query, x => x.Category);
    }
}
