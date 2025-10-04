using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Application.BranchUseCases;

public class BranchProfile:MappingProfile<Branch,CreateBranchDto,UpdateBranchDto,BranchListDto,BranchDto,LiteBranchDto>
{

}
