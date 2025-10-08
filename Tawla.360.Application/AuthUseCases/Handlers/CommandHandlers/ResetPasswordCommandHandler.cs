using System;
using MediatR;
using Tawla._360.Application.AuthUseCases.Commands;
using Tawla._360.Application.UsersUseCases;

namespace Tawla._360.Application.AuthUseCases.Handlers.CommandHandlers;

internal class ResetPasswordCommandHandler : INotificationHandler<ResetPasswordCommand>
{
    private readonly IUserService _userService;
    public ResetPasswordCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task Handle(ResetPasswordCommand notification, CancellationToken cancellationToken)
    {
        return _userService.ResetPassword(notification.Email, notification.Token, notification.NewPassword);
    }
}
