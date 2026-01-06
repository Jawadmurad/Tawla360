
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Application.TableUseCases;

public interface ITableService:IHasBranchService<Table,CreateTableDto,UpdateTableDto,TableDto,TableDto,TableDto>
{

}
