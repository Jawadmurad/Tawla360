using System;
using MediatR;
using Tawla._360.Application.BranchUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.BranchUseCases.Handlers.CommandHandlers;

internal class DeleteBranchCommandHandler : INotificationHandler<DeleteBranchCommand>
{
    private readonly IBranchService _branchService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBranchCommandHandler(IBranchService branchService, IUnitOfWork unitOfWork)
    {
        _branchService = branchService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteBranchCommand notification, CancellationToken cancellationToken)
    {
        await _branchService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
