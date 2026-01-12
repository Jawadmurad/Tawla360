using MediatR;
using Tawla._360.Application.SupplierUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SupplierUseCases.Handlers.CommandsHandler;

public record class DeleteSupplierCommandHandler : INotificationHandler<DeleteSupplierCommand>
{
    private readonly ISupplierService _supplierService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteSupplierCommandHandler(ISupplierService supplierService, IUnitOfWork unitOfWork)
    {
        _supplierService = supplierService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteSupplierCommand notification, CancellationToken cancellationToken)
    {
        await _supplierService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
