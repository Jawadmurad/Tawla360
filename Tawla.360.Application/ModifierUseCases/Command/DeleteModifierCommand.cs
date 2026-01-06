using MediatR;

namespace Tawla._360.Application.ModifierUseCases.Command;

public record  DeleteModifierCommand(Guid Id):INotification;
