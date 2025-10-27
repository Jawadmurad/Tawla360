using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.Constants;
using Tawla._360.Domain.Entities.UsersEntities;
using Tawla._360.Domain.Repositories.UserRepositories;

namespace Tawla._360.Application.AuthUseCases;

public class JwtService : IJwtService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IConfiguration _config;
    public JwtService(UserManager<ApplicationUser> userManager,
RoleManager<ApplicationRole> roleManager, IRefreshTokenRepository refreshTokenRepository,
IConfiguration config)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _refreshTokenRepository = refreshTokenRepository;
        _config = config;
    }
    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<AuthResponse> GenerateTokensAsync(ApplicationUser user)
    {
        var jwtSettings = _config.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])) ?? throw new InvalidOperationException("JWT Key is missing in configuration.");

         var roleNames = await _userManager.GetRolesAsync(user);

        var roles = await _roleManager.Roles
            .Where(r => roleNames.Contains(r.Name))
            .ToListAsync();


        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, user.Email),
            new (JwtRegisteredClaimNames.GivenName, user.FirstName),
            new (JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
            new (CustomClaim.UserType, ((int)user.UserType).ToString()),
            new (CustomClaim.RestaurantId, user.RestaurantId?.ToString()??string.Empty),
        };


        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"]));

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        var refreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = GenerateRefreshToken(),
            UserId = user.Id,
            ExpiryDate = DateTime.UtcNow.AddDays(7)
        };
        await _refreshTokenRepository.AddAsync(refreshToken);

        return new AuthResponse
        {
            Token = jwt,
            RefreshToken = refreshToken.Token,
            Expiration = expires,
            Permissions = roles.SelectMany(c => c.Permissions)
        };
    }

    public async Task<AuthResponse> RefreshToken(string refreshToken)
    {
        var token = await _refreshTokenRepository.FirstOrDefaultAsync(c => c.Token == refreshToken);
        if (token == null)
        {
            //TODO throw error
        }
        if (token.ExpiryDate < DateTime.UtcNow)
        {
            //TODO throw error
        }
        var user = await _userManager.FindByIdAsync(token.UserId.ToString());
        await _refreshTokenRepository.DeleteWithSaveAsync(token);
        return await GenerateTokensAsync(user);

    }
}