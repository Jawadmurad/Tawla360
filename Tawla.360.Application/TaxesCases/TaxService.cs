using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Services;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Domain.Entities.Settings;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TaxesUseCases;

public class TaxService : HasBranchService<Tax, CreateTaxDto, UpdateTaxDto, TaxListDto, TaxDto, TaxLiteDto>,ITaxService
{
    public TaxService(IHasIdRepository<Tax> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
