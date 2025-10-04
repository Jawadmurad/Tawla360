using MediatR;
using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.BranchUseCases.Queries;

public record class GetBranchPagedQuery(QueryRequestDto Query):IRequest<PagingResult<BranchListDto>>;
