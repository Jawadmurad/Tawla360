using System;
using MediatR;
using Tawla._360.Application.SupplierUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SupplierUseCases.Handlers.CommandsHandler;

public class CreateSupplierCommandHandler : INotificationHandler<CreateSupplierCommand>
{
    private readonly ISupplierService _supplierService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSupplierCommandHandler(ISupplierService supplierService, IUnitOfWork unitOfWork)
    {
        _supplierService = supplierService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateSupplierCommand notification, CancellationToken cancellationToken)
    {
        await _supplierService.CreateAsync(notification.CreateSupplier);
        await _unitOfWork.SaveChangesAsync();
    }
}
