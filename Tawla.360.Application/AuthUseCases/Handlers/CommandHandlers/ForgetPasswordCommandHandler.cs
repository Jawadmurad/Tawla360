using System;
using MediatR;
using Tawla._360.Application.AuthUseCases.Commands;
using Tawla._360.Application.UsersUseCases;

namespace Tawla._360.Application.AuthUseCases.Handlers.CommandHandlers;

public class ForgetPasswordCommandHandler : INotificationHandler<ForgetPasswordCommand>
{
    private readonly IUserService _userService;
    public ForgetPasswordCommandHandler(IUserService userService)
    {
        _userService=userService;
    }
    public Task Handle(ForgetPasswordCommand notification, CancellationToken cancellationToken)
    {
        return _userService.ForgetPassword(notification.Email);
    }
}
