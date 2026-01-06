using MediatR;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Application.ModifierUseCases.Query;

namespace Tawla._360.Application.ModifierUseCases.Handler.QueriesHandlers;

public class GetModifierLiteQueryHandler : IRequestHandler<GetModifierLiteQuery, IReadOnlyList<ModifierLiteDto>>
{
    private readonly IModifierService _modifierService;
    public Task<IReadOnlyList<ModifierLiteDto>> Handle(GetModifierLiteQuery request, CancellationToken cancellationToken)
    {
        return _modifierService.GetLiteAsync();
    }
}
