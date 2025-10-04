using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Application.BranchUseCases;

public interface IBranchService:IHasIdGenericService<Branch,CreateBranchDto,UpdateBranchDto,BranchListDto,BranchDto,LiteBranchDto>
{

}
