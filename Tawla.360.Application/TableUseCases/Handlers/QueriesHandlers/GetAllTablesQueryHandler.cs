using System;
using MediatR;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Application.TableUseCases.Queries;

namespace Tawla._360.Application.TableUseCases.Handlers.QueriesHandlers;

public class GetAllTablesQueryHandler : IRequestHandler<GetAllTablesQuery, IEnumerable<TableDto>>
{
    public Task<IEnumerable<TableDto>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
