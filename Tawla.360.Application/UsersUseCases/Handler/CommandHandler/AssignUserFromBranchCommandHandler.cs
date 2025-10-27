using System;
using MediatR;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.UsersUseCases.Handler.CommandHandler;

public class AssignUserFromBranchCommandHandler : INotificationHandler<AssignUserFromBranchCommand>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    public AssignUserFromBranchCommandHandler(IUserService userService,IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(AssignUserFromBranchCommand notification, CancellationToken cancellationToken)
    {
        await _userService.AssignUserToBranch(notification.UserId, notification.BranchId);
        await _unitOfWork.SaveChangesAsync();
    }
}
