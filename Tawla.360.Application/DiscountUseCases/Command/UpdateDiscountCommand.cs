using System;
using MediatR;
using Tawla._360.Application.DiscountUseCases.Dtos;

namespace Tawla._360.Application.DiscountUseCases.Command;

public record UpdateDiscountCommand(UpdateDiscountDto UpdateDiscount):INotification;
