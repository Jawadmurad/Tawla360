using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.TaxesCases;

public class TaxProfile:MappingProfile<Tax,CreateTaxDto,UpdateTaxDto,TaxListDto,TaxDto,TaxListDto>
{

}
