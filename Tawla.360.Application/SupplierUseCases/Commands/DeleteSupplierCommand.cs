using MediatR;

namespace Tawla._360.Application.SupplierUseCases.Commands;

public record class DeleteSupplierCommand(Guid Id):INotification;
