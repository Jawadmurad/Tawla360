using System;
using MediatR;
using Tawla._360.Application.TaxesCases.Commands;
using Tawla._360.Application.TaxesUseCases;
using Tawla._360.Domain.Exceptions;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TaxesCases.Handlers.CommandsHandlers;

internal class DeleteTaxCommandHandler : INotificationHandler<DeleteTaxCommand>
{
    private readonly ITaxService _taxService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTaxCommandHandler(ITaxService taxService,IUnitOfWork unitOfWork)
    {
        _taxService = taxService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteTaxCommand   notification, CancellationToken cancellationToken)
    {
        if (await _taxService.AnyAsync(x => x.Id == notification.Id && x.BranchTaxes.Any()))
        {
            //TODO add the error messages 
            throw new BadRequestException("");
        }
        await _taxService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
