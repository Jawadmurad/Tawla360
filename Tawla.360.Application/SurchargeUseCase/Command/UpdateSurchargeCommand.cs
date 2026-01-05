using MediatR;
using Tawla._360.Application.SurchargeUseCase.Dto;

namespace Tawla._360.Application.SurchargeUseCase.Command;

public record UpdateSurchargeCommand(UpdateSurchargeDto UpdateSurcharge):INotification;
