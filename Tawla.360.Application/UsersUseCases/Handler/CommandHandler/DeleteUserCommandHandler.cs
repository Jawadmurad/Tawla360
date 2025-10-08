using System;
using MediatR;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.UsersUseCases.Handler.CommandHandler;

public class DeleteUserCommandHandler : INotificationHandler<DeleteUserCommand>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUserCommandHandler(IUserService userService,IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteUserCommand notification, CancellationToken cancellationToken)
    {
        await _userService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
