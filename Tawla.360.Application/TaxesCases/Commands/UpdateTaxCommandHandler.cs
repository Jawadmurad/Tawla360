using System;
using MediatR;
using Tawla._360.Application.TaxesUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TaxesCases.Commands;

public class UpdateTaxCommandHandler : INotificationHandler<UpdateTaxCommand>
{
    private readonly ITaxService _taxService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateTaxCommandHandler(ITaxService taxService,IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _taxService = taxService;
    }
    public async Task Handle(UpdateTaxCommand notification, CancellationToken cancellationToken)
    {
        _taxService.Update(notification.UpdateTax);
        await _unitOfWork.SaveChangesAsync();
    }
}
