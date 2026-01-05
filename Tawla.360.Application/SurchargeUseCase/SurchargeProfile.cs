using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.SurchargeUseCase;

public class SurchargeProfile:TranslatedEntityProfile<Surcharge,SurchargeTranslation,CreateSurchargeDto,UpdateSurchargeDto,SurchargeListDto,SurchargeDto,SurchargeLiteDto>
{

}
