using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.DiscountUseCases;

public class DiscountProfile
    : TranslatedEntityProfile<Discount, DiscountTranslation, CreateDiscountDto, UpdateDiscountDto, DiscountListDot, DiscountDto, LiteDiscountDto>
{
    public DiscountProfile()
    {
        
    }
}
