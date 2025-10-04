using MediatR;
using Tawla._360.Application.BranchUseCases.Dtos;

namespace Tawla._360.Application.BranchUseCases.Commands;

public record class CreateBranchCommand(CreateBranchDto CreateBranch):INotification;
