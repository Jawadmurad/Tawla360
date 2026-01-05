using System;
using MediatR;
using Tawla._360.Application.SurchargeUseCase.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SurchargeUseCase.Handler.CommandHandlers;

public class UpdateSurchargeCommandHandler : INotificationHandler<UpdateSurchargeCommand>
{
    private readonly ISurchargeService _surchargeService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateSurchargeCommandHandler(ISurchargeService surchargeService,IUnitOfWork unitOfWork)
    {
        _surchargeService =surchargeService;
        _unitOfWork=unitOfWork;
    }
    public async Task Handle(UpdateSurchargeCommand notification, CancellationToken cancellationToken)
    {
        _surchargeService.Update(notification.UpdateSurcharge);
        await _unitOfWork.SaveChangesAsync();
    }
}
