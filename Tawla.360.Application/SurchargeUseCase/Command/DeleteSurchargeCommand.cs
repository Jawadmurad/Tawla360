using MediatR;

namespace Tawla._360.Application.SurchargeUseCase.Command;

public record class DeleteSurchargeCommand(Guid Id):INotification;
