using System;
using MediatR;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.AuthUseCases.Queries;
using Tawla._360.Application.UsersUseCases;

namespace Tawla._360.Application.AuthUseCases.Handlers.QueriesHandler;

public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, AuthResponse>
{
    private readonly IJwtService _jwtService;
    public RefreshTokenQueryHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }
    public Task<AuthResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        return _jwtService.RefreshToken(request.RefreshToken);
    }
}
