using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Application.RestaurantUseCases;

public class RestaurantProfile : MappingProfile<Restaurant, CreateRestaurantDto, UpdateRestaurantDto, ListRestaurantDto, RestaurantDto, LiteRestaurantDto>
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantDto, Restaurant>()
    .ForMember(dest => dest.Branches, opt => opt.MapFrom(src =>
        new List<Branch>
        {
            new ()
            {
                Number = 1,
                Location = src.MainBranchLocation
            }
        }));

    }
}
