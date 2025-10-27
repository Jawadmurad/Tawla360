using MediatR;

namespace Tawla._360.Application.UsersUseCases.Commands;

public record UnAssignUserFromBranchCommand(Guid UserId, Guid BranchId):INotification;
