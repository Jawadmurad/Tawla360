using System;
using MediatR;
using Tawla._360.Application.RoleUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RoleUseCases.Handlers.CommandHandlers;

public class DeleteRoleCommandHandler : INotificationHandler<DeleteRoleCommand>
{
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteRoleCommandHandler(IRoleService roleService,IUnitOfWork unitOfWork)
    {
        _roleService = roleService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteRoleCommand notification, CancellationToken cancellationToken)
    {
        await _roleService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
