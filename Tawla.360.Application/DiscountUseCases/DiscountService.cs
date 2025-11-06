using System;
using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.Settings;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.DisCountUseCases;

public class DiscountService : HasBranchService<Discount, CreateDiscountDto, UpdateDiscountDto, DiscountListDot, DiscountDto, LiteDiscountDto>, IDiscountService
{
    public DiscountService(IHasIdRepository<Discount> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
