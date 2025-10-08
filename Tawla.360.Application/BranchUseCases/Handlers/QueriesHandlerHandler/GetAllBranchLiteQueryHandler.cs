using MediatR;
using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.BranchUseCases.Queries;

namespace Tawla._360.Application.BranchUseCases.Handlers.QueriesHandlerHandler;

public class GetAllBranchLiteQueryHandler : IRequestHandler<GetAllBranchLiteQuery, IReadOnlyList<LiteBranchDto>>
{
    private readonly IBranchService _branchService;
    public GetAllBranchLiteQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }
    public Task<IReadOnlyList<LiteBranchDto>> Handle(GetAllBranchLiteQuery request, CancellationToken cancellationToken)
    {
        return _branchService.GetLiteAsync();
    }
}
