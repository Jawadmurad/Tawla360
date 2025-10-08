using MediatR;

namespace Tawla._360.Application.UsersUseCases.Commands;

public record DeleteUserCommand(Guid Id):INotification;
