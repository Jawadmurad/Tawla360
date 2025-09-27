using MediatR;
using Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;

namespace Tawla._360.Application.RestaurantUseCases.Commands;

public record class CreateRestaurantCommand(CreateRestaurantWithAdmin  CreateRestaurantWithAdminDto):INotification;
