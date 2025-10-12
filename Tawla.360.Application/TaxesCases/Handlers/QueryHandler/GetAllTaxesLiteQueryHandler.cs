using System;
using MediatR;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Application.TaxesCases.Queries;
using Tawla._360.Application.TaxesUseCases;

namespace Tawla._360.Application.TaxesCases.Handlers.QueryHandler;

public class GetAllTaxesLiteQueryHandler : IRequestHandler<GetAllTaxesLiteQuery, IReadOnlyList<TaxLiteDto>>
{
    private readonly ITaxService _taxService;
    public GetAllTaxesLiteQueryHandler(ITaxService taxService)
    {
        _taxService = taxService;
    }
    public Task<IReadOnlyList<TaxLiteDto>> Handle(GetAllTaxesLiteQuery request, CancellationToken cancellationToken)
    {
        return _taxService.GetLiteAsync();
    }
}
