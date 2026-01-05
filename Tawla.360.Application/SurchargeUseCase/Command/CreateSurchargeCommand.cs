using MediatR;
using Tawla._360.Application.SurchargeUseCase.Dto;

namespace Tawla._360.Application.SurchargeUseCase.Command;

public record class CreateSurchargeCommand(CreateSurchargeDto CreateSurcharge):INotification;
