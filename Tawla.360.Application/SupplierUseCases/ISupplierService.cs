using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.SupplierUseCases.Dto;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.SupplierUseCases;

public interface ISupplierService:IHasRestaurantService<Supplier,CreateSupplierDto,UpdateSupplierDto,SupplierDto,SupplierDto,SupplierDto>
{

}
