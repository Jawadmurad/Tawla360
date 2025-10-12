using System;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Application.AuthUseCases;

public interface IJwtService
{
    Task<AuthResponse> GenerateTokensAsync(ApplicationUser user);
    Task<AuthResponse> RefreshToken(string refreshToken);
}
