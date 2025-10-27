using MediatR;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.UsersUseCases.Handler.CommandHandler;

public class UnAssignUserFromBranchCommandHandler : INotificationHandler<UnAssignUserFromBranchCommand>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    public UnAssignUserFromBranchCommandHandler(IUserService userService,IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UnAssignUserFromBranchCommand notification, CancellationToken cancellationToken)
    {
        await _userService.UnAssignUserToBranch(notification.UserId, notification.BranchId);
        await _unitOfWork.SaveChangesAsync();
    }
}
