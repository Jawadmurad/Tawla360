using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Constants;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Exceptions;

namespace Tawla._360.Application.Services;

public class HttpContextAccessorService : IHttpContextAccessorService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public HttpContextAccessorService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Guid? GetRestaurantId()
    {
        var user = GetUser();
        if (!user.Identity.IsAuthenticated)
            return null;
        return Guid.Parse(GetClaim(CustomClaim.RestaurantId));
    }
    public string GetClaim(string claimType)
    {
        string result = string.Empty;
        var user = GetUser();
        if (!user.Claims.Any(c => c.Type == claimType))
            return result;
        return user.FindFirst(claimType).Value;
    }
    private ClaimsPrincipal GetUser()
    {
        return _httpContextAccessor?.HttpContext?.User;
    }

    public UserType GetUserType()
    {
        var user = GetUser();
        if (!user.Identity.IsAuthenticated)
            //TODO put a correct exception 
            throw new Exception();
        return (UserType)int.Parse(GetClaim(CustomClaim.RestaurantId));
    }

    public Guid? GetUserId()
    {
        var user = GetUser();
        if (!user.Identity.IsAuthenticated)
        {
            return null;
        }
        var data = GetClaim(JwtRegisteredClaimNames.Sub);
        return Guid.Parse(data);
    }

    public Guid GetBranchId()
    {
        var branchId = GetHeaderValue("branch-id");
        if (string.IsNullOrEmpty(branchId))
        {
            throw new BadRequestException("branch id can't be null");
        }
        return Guid.Parse(branchId);
    }

    private string GetHeaderValue(string key)
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null)
            return null;

        if (context.Request.Headers.TryGetValue(key, out var headerValue))
        {
            return headerValue.ToString();
        }

        return null;
    }

    public string GetAcceptedLanguage() => GetHeaderValue("Accept-Language");

}
