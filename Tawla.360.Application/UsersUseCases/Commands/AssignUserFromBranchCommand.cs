using MediatR;

namespace Tawla._360.Application.UsersUseCases.Commands;

public  record AssignUserFromBranchCommand(Guid UserId,Guid BranchId):INotification;
