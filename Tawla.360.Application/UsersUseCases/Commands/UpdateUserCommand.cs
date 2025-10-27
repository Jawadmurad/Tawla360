using MediatR;
using Tawla._360.Application.UsersUseCases.Dtos;

namespace Tawla._360.Application.UsersUseCases.Commands;

public record  UpdateUserCommand(UpdateUserDto UpdateUser):INotification;
