using MediatR;

namespace Tawla._360.Application.TaxesCases.Commands;

public record class DeleteTaxCommand(Guid Id):INotification;
