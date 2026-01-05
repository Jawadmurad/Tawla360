using System;
using MediatR;
using Tawla._360.Application.SurchargeUseCase.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SurchargeUseCase.CommandHandlers.Handler;

public class CreateSurchargeCommandHandler : INotificationHandler<CreateSurchargeCommand>
{
    private readonly ISurchargeService _surchargeService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSurchargeCommandHandler(ISurchargeService surchargeService,IUnitOfWork unitOfWork)
    {
        _surchargeService=surchargeService; 
        _unitOfWork=unitOfWork;
    }
    public async Task Handle(CreateSurchargeCommand notification, CancellationToken cancellationToken)
    {
        await _surchargeService.CreateAsync(notification.CreateSurcharge);
        await _unitOfWork.SaveChangesAsync();
    }
}
