using MediatR;

namespace Tawla._360.Application.DiscountUseCases.Command;

public record  DeleteDiscountCommand(Guid Id):INotification;
