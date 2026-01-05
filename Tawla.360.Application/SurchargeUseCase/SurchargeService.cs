using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Services;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Domain.Entities.Settings;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SurchargeUseCase;

public class SurchargeService : HasBranchService<Surcharge, CreateSurchargeDto, UpdateSurchargeDto, SurchargeListDto, SurchargeDto, SurchargeLiteDto>, ISurchargeService
{
    public SurchargeService(IHasIdRepository<Surcharge> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
