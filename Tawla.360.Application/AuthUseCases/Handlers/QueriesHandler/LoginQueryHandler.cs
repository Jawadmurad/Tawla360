using System;
using MediatR;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.AuthUseCases.Queries;
using Tawla._360.Application.UsersUseCases;

namespace Tawla._360.Application.AuthUseCases.Handlers.QueriesHandler;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResponse>
{
    private readonly IUserService _userService;
    public LoginQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        return _userService.Login(request.LoginRequest);
    }
}
