using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.MeasurementUnitUserCases.Dtos;

public record class UpdateMeasurementUnitDto : IHasId
{
    public Guid Id {get;set;}
}
