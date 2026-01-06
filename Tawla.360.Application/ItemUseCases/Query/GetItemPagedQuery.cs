using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.ItemUseCases.Query;

public record  GetItemPagedQuery(QueryRequestDto Query):IRequest<PagingResult<ItemListDto>>;
