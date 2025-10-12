using AutoMapper;
using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.BranchUseCases;

public class BranchService : HasRestaurantService<Branch, CreateBranchDto, UpdateBranchDto, BranchListDto, BranchDto, LiteBranchDto>, IBranchService
{

    public BranchService(IHasIdRepository<Branch> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
    public override async Task<BranchDto> CreateAsync(CreateBranchDto createDto)
    {
        var lastBranch = await _repository.MaxAsync(c => c.Number, c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
        var branch = new Branch()
        {
            Location = createDto.Location,
            Number = lastBranch++
        };
        await CreateAsync(branch);
        return _mapper.Map<BranchDto>(branch);
    }
}
