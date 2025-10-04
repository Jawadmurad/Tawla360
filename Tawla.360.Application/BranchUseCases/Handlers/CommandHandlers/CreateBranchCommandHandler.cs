using MediatR;
using Tawla._360.Application.BranchUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.BranchUseCases.Handlers.CommandHandlers;

public class CreateBranchCommandHandler : INotificationHandler<CreateBranchCommand>
{
    private readonly IBranchService _branchService;
    private readonly IUnitOfWork _unitOfWork;
    
    public Task Handle(CreateBranchCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
