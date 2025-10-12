using System;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Application.Common.ServicesInterfaces;

public interface IHttpContextAccessorService
{

    Guid? GetRestaurantId();
    UserType GetUserType();
    Guid? GetUserId();
    Guid? GetBranchId();
}
