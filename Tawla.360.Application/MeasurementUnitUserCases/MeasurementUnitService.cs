using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.Settings;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.MeasurementUnitUserCases;

public class MeasurementUnitService : HasRestaurantService<MeasurementUnit, CreateMeasurementUnitDto, UpdateMeasurementUnitDto, MeasurementUnitListDto, MeasurementUnitDto, MeasurementUnitLiteDto>, IMeasurementUnitService
{
    public MeasurementUnitService(IHasIdRepository<MeasurementUnit> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
