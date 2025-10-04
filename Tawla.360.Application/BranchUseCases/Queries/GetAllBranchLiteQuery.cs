using MediatR;
using Tawla._360.Application.BranchUseCases.Dtos;

namespace Tawla._360.Application.BranchUseCases.Queries;

public record class GetAllBranchLiteQuery:IRequest<IReadOnlyList<LiteBranchDto>>;
