using System;
using MediatR;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Application.TableUseCases.Queries;
using Tawla._360.Shared;

namespace Tawla._360.Application.TableUseCases.Handlers.QueriesHandlers;

public class GetTablePagedQueryHandler : IRequestHandler<GetTablePagedQuery, PagingResult<TableDto>>
{
    private readonly ITableService  _tableService;
    public Task<PagingResult<TableDto>> Handle(GetTablePagedQuery request, CancellationToken cancellationToken)
    {
        return _tableService.GetPagedAsync(request.Query);
    }
}
