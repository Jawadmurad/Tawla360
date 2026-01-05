using System;
using MediatR;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.TaxesCases.Commands;
using Tawla._360.Application.TaxesUseCases;
using Tawla._360.Domain.Exceptions;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TaxesCases.Handlers.CommandsHandlers;

public class CreateTaxCommandHandler : INotificationHandler<CreateTaxCommand>
{
    private readonly ITaxService _taxService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    public CreateTaxCommandHandler(ITaxService taxService,IUnitOfWork unitOfWork,IHttpContextAccessorService httpContextAccessorService)
    {
        _taxService = taxService;
        _unitOfWork = unitOfWork;
        _httpContextAccessorService=httpContextAccessorService;
    }
    public async Task Handle(CreateTaxCommand notification, CancellationToken cancellationToken)
    {
        if(await _taxService.AnyAsync(c =>c.BranchId==_httpContextAccessorService.GetBranchId() && c.IsVat)&&notification.CreateTax.IsVat)
        {
            throw new BadRequestException("");
         }
        await _taxService.CreateAsync(notification.CreateTax);
        await _unitOfWork.SaveChangesAsync();
    }
}
