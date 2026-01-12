using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.MeasurementUnitUserCases;

public interface IMeasurementUnitService:IHasRestaurantService<MeasurementUnit,CreateMeasurementUnitDto,UpdateMeasurementUnitDto,MeasurementUnitListDto,MeasurementUnitDto,MeasurementUnitLiteDto>
{

}
