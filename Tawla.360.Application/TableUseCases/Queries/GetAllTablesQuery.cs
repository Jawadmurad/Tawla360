using MediatR;
using Tawla._360.Application.TableUseCases.Dtos;

namespace Tawla._360.Application.TableUseCases.Queries;

public record class GetAllTablesQuery:IRequest<IReadOnlyList<TableDto>>;
