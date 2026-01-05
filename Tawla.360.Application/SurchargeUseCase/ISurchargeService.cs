using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.SurchargeUseCase;

public interface ISurchargeService:IHasBranchService<Surcharge,CreateSurchargeDto,UpdateSurchargeDto,SurchargeListDto,SurchargeDto,SurchargeLiteDto>
{

}
