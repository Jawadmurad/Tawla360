using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.TableUseCases.Queries;

public record class GetTablePagedQuery(QueryRequestDto Query):IRequest<PagingResult<TableDto>>;
