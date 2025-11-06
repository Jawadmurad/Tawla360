using System;
using MediatR;
using Tawla._360.Application.TaxesCases.Commands;
using Tawla._360.Application.TaxesUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TaxesCases.Handlers.CommandsHandlers;

public class CreateTaxCommandHandler : INotificationHandler<CreateTaxCommand>
{
    private readonly ITaxService _taxService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateTaxCommandHandler(ITaxService taxService,IUnitOfWork unitOfWork)
    {
        _taxService = taxService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateTaxCommand notification, CancellationToken cancellationToken)
    {
        if(await _taxService.AnyAsync(c => c.IsVat)&&notification.CreateTax.IsVat)
        {
            //TODO: throw ex
         }
        await _taxService.CreateAsync(notification.CreateTax);
        await _unitOfWork.SaveChangesAsync();
    }
}
