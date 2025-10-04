using System;
using AutoMapper;
using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.BranchUseCases;

public class BranchService : HasIdGenericService<Branch, CreateBranchDto, UpdateBranchDto, BranchListDto, BranchDto, LiteBranchDto>, IBranchService
{
    public BranchService(IHasIdRepository<Branch> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
