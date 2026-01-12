using MediatR;
using Tawla._360.Application.SupplierUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SupplierUseCases.Handlers.CommandsHandler;

public class UpdateSupplierCommandHandler : INotificationHandler<UpdateSupplierCommand>
{
    private readonly ISupplierService _supplierService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateSupplierCommandHandler(ISupplierService supplierService, IUnitOfWork unitOfWork)
    {
        _supplierService = supplierService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateSupplierCommand notification, CancellationToken cancellationToken)
    {
        _supplierService.Update(notification.UpdateSupplier);
        await _unitOfWork.SaveChangesAsync();
    }
}
