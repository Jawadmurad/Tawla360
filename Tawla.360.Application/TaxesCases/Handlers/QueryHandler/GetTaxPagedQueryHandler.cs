using System;
using MediatR;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Application.TaxesCases.Queries;
using Tawla._360.Application.TaxesUseCases;
using Tawla._360.Shared;

namespace Tawla._360.Application.TaxesCases.Handlers.QueryHandler;

public class GetTaxPagedQueryHandler : IRequestHandler<GetTaxPagedQuery, PagingResult<TaxListDto>>
{
    private readonly ITaxService _taxService;
    public GetTaxPagedQueryHandler(ITaxService taxService)
    {
        _taxService=taxService;
    }
    public Task<PagingResult<TaxListDto>> Handle(GetTaxPagedQuery request, CancellationToken cancellationToken)
    {
        return _taxService.GetPagedAsync(request.Query);
    }
}
