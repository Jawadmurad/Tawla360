using System;
using MediatR;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Application.TableUseCases.Queries;

namespace Tawla._360.Application.TableUseCases.Handlers.QueriesHandlers;

public class GetAllTablesQueryHandler : IRequestHandler<GetAllTablesQuery, IReadOnlyList<TableDto>>
{
    private readonly ITableService _tableService;

    public GetAllTablesQueryHandler(ITableService tableService)
    {
        _tableService = tableService;
    }

    public Task<IReadOnlyList<TableDto>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
    {
        return _tableService.GetAllAsync();
    }
}
