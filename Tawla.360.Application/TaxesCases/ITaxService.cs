using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.TaxesUseCases;

public interface ITaxService:IHasBranchService<Tax,CreateTaxDto,UpdateTaxDto,TaxListDto,TaxDto,TaxLiteDto>
{

}
