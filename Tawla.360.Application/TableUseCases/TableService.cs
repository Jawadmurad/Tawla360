using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Services;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TableUseCases;

public class TableService : HasBranchService<Table, CreateTableDto, UpdateTableDto, TableDto, TableDto, TableDto>, ITableService
{
    public TableService(IHasIdRepository<Table> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
