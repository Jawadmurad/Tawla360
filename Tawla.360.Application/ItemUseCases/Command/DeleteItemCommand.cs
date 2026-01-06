using MediatR;

namespace Tawla._360.Application.ItemUseCases.Command;

public record class DeleteItemCommand(Guid Id):INotification;
