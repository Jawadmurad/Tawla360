using System;
using MediatR;
using Tawla._360.Application.ModifierUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ModifierUseCases.Handler.CommandsHandler;

public class CreateModifierCommandHandler : INotificationHandler<CreateModifierCommand>
{
    private readonly IModifierService _modifierService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateModifierCommandHandler(IModifierService modifierService,IUnitOfWork unitOfWork)
    {
        _modifierService=modifierService;
        _unitOfWork=unitOfWork;
    }
    public async Task Handle(CreateModifierCommand notification, CancellationToken cancellationToken)
    {
       await _modifierService.CreateAsync(notification.CreateModifier);
      await _unitOfWork.SaveChangesAsync();
    }
}
