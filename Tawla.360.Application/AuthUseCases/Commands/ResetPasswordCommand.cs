using MediatR;

namespace Tawla._360.Application.AuthUseCases.Commands;

public record  ResetPasswordCommand(string Email, string Token, string NewPassword):INotification;
