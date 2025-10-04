using MediatR;
using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.BranchUseCases.Queries;
using Tawla._360.Shared;

namespace Tawla._360.Application.BranchUseCases.Handlers.QueriesHandlerHandler;

public class GetBranchPagedQueryHandler : IRequestHandler<GetBranchPagedQuery, PagingResult<BranchListDto>>
{
    private readonly IBranchService _branchService;

    public GetBranchPagedQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }
    public Task<PagingResult<BranchListDto>> Handle(GetBranchPagedQuery request, CancellationToken cancellationToken)
    {
        return _branchService.GetPagedAsync(request.Query);
    }
}
