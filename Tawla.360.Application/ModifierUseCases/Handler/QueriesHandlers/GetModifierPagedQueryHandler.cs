using System;
using MediatR;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Application.ModifierUseCases.Query;
using Tawla._360.Shared;

namespace Tawla._360.Application.ModifierUseCases.Handler.QueriesHandlers;

public class GetModifierPagedQueryHandler : IRequestHandler<GetModifierPagedQuery, PagingResult<ModifierListDto>>
{
    private readonly IModifierService _modifierService;
    public GetModifierPagedQueryHandler(IModifierService modifierService)
    {
        _modifierService=modifierService;
    }
    public Task<PagingResult<ModifierListDto>> Handle(GetModifierPagedQuery request, CancellationToken cancellationToken)
    {
        return _modifierService.GetPagedAsync(request.Query);
    }
}
