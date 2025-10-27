using System;
using MediatR;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Application.UsersUseCases.Query;

namespace Tawla._360.Application.UsersUseCases.Handler.QueryHandler;

public class GetAllUsersLiteQueryHandler : IRequestHandler<GetAllUsersLiteQuery, IReadOnlyList<LiteUserDto>>
{
    private readonly IUserService _userService;
    public GetAllUsersLiteQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<IReadOnlyList<LiteUserDto>> Handle(GetAllUsersLiteQuery request, CancellationToken cancellationToken)
    {
        return _userService.GetLiteAsync();
    }
}
