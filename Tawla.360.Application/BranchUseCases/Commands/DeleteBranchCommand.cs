using MediatR;

namespace Tawla._360.Application.BranchUseCases.Commands;

public record class DeleteBranchCommand(Guid Id):INotification;
