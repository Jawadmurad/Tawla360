using System;
using MediatR;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.UsersUseCases.Handler.CommandHandler;

public class UpdateUserCommandHandler : INotificationHandler<UpdateUserCommand>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserCommandHandler(IUserService userService,IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    public Task Handle(UpdateUserCommand notification, CancellationToken cancellationToken)
    {
        _userService.Update(notification.UpdateUser);
        return _unitOfWork.SaveChangesAsync();
    }
}
