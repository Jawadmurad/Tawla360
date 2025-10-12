using System;
using MediatR;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.UsersUseCases.Handler.CommandHandler;

public class CreateUserCommandHandler : INotificationHandler<CreateUserCommand>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateUserCommand notification, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _userService.CreateAsync(notification.CreateUser);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.Rollback();
        }

    }
}
