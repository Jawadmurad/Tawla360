using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.UsersUseCases.Query;

public record class GetUserPagedQuery(QueryRequestDto QueryRequest):IRequest<PagingResult<UserListDto>>;
