using System;
using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Services;
using Tawla._360.Application.SupplierUseCases.Dto;
using Tawla._360.Domain.Entities.Settings;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.SupplierUseCases;

public class SupplierService : HasRestaurantService<Supplier, CreateSupplierDto, UpdateSupplierDto, SupplierDto, SupplierDto, SupplierDto>,ISupplierService
{
    public SupplierService(IHasIdRepository<Supplier> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
