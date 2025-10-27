using System;
using MediatR;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Application.UsersUseCases.Query;
using Tawla._360.Shared;

namespace Tawla._360.Application.UsersUseCases.Handler.QueryHandler;

public class GetUserPagedQueryHandler : IRequestHandler<GetUserPagedQuery, PagingResult<UserListDto>>
{
    private readonly IUserService _userService;
    public GetUserPagedQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<PagingResult<UserListDto>> Handle(GetUserPagedQuery request, CancellationToken cancellationToken)
    {
        return _userService.GetPagedAsync(request.QueryRequest);
    }
}
