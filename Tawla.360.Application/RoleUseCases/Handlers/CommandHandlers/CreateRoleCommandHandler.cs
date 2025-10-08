using System;
using MediatR;
using Tawla._360.Application.RoleUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RoleUseCases.Handlers.CommandHandlers;

public class CreateRoleCommandHandler : INotificationHandler<CreateRoleCommand>
{
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateRoleCommandHandler(IRoleService roleService, IUnitOfWork unitOfWork)
    {
        _roleService = roleService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateRoleCommand notification, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(notification.CreateRole);
        await _unitOfWork.SaveChangesAsync();
    }
}
