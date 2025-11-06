using System;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Application.DisCountUseCases;

public interface IDiscountService:IHasBranchService<Discount,CreateDiscountDto,UpdateDiscountDto,DiscountListDot,DiscountDto,LiteDiscountDto>
{

}
