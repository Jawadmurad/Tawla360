using MediatR;

namespace Tawla._360.Application.RestaurantUseCases.Commands;

public record class DeleteRestaurantCommand(Guid Id):INotification;
