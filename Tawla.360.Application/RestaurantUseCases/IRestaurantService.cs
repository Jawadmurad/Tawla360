using System;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Application.RestaurantUseCases;

public interface IRestaurantService:IHasIdGenericService<Restaurant,CreateRestaurantDto,UpdateRestaurantDto,ListRestaurantDto,RestaurantDto,LiteRestaurantDto>
{
}
