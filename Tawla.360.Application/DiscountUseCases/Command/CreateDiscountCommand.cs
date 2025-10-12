using MediatR;
using Tawla._360.Application.DiscountUseCases.Dtos;

namespace Tawla._360.Application.DiscountUseCases.Command;

public record  CreateDiscountCommand(CreateDiscountDto CreateDiscount):INotification;