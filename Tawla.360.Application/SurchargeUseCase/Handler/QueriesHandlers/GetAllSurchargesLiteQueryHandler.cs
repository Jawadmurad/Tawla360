using MediatR;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Application.SurchargeUseCase.Queries;

namespace Tawla._360.Application.SurchargeUseCase.Handler.QueriesHandlers;

public class GetAllSurchargesLiteQueryHandler : IRequestHandler<GetAllSurchargesLiteQuery, IReadOnlyList<SurchargeLiteDto>>
{
    private readonly ISurchargeService _surchargeService;
    public GetAllSurchargesLiteQueryHandler(ISurchargeService surchargeService)
    {
        _surchargeService=surchargeService;
    }
    public Task<IReadOnlyList<SurchargeLiteDto>> Handle(GetAllSurchargesLiteQuery request, CancellationToken cancellationToken)
    {
        return _surchargeService.GetLiteAsync();
    }
}
