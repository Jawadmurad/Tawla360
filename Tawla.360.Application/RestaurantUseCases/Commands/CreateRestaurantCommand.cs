using MediatR;
using Tawla._360.Application.RestaurantUseCases.Dtos;

namespace Tawla._360.Application.RestaurantUseCases.Commands;

public record class CreateRestaurantCommand(CreateRestaurantDto CreateRestaurant):INotification;
