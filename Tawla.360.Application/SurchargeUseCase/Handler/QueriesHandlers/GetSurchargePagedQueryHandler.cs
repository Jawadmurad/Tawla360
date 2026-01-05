using System;
using MediatR;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Application.SurchargeUseCase.Queries;
using Tawla._360.Shared;

namespace Tawla._360.Application.SurchargeUseCase.Handler.QueriesHandlers;

public class GetSurchargePagedQueryHandler : IRequestHandler<GetSurchargePagedQuery, PagingResult<SurchargeListDto>>
{
    private readonly ISurchargeService _surchargeService;
    public GetSurchargePagedQueryHandler(ISurchargeService surchargeService)
    {
        _surchargeService=surchargeService;
    }
    public Task<PagingResult<SurchargeListDto>> Handle(GetSurchargePagedQuery request, CancellationToken cancellationToken)
    {
        return _surchargeService.GetPagedAsync(request.Query);
    }
}
