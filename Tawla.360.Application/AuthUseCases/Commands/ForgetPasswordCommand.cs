using MediatR;

namespace Tawla._360.Application.AuthUseCases.Commands;

public record class ForgetPasswordCommand(string Email):INotification;
