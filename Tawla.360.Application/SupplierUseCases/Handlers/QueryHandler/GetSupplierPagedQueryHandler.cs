using System;
using MediatR;
using Tawla._360.Application.SupplierUseCases.Dto;
using Tawla._360.Application.SupplierUseCases.Queries;
using Tawla._360.Shared;

namespace Tawla._360.Application.SupplierUseCases.Handlers.QueryHandler;

public class GetSupplierPagedQueryHandler : IRequestHandler<GetSupplierPagedQuery, PagingResult<SupplierDto>>
{
    private readonly ISupplierService _supplierService;
    public GetSupplierPagedQueryHandler(ISupplierService supplierService)
    {
        _supplierService=supplierService;
    }
    public Task<PagingResult<SupplierDto>> Handle(GetSupplierPagedQuery request, CancellationToken cancellationToken)
    {
        return _supplierService.GetPagedAsync(request.Query);
    }
}
