using MediatR;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.AuthUseCases.Queries;
using Tawla._360.Application.UsersUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.AuthUseCases.Handlers.QueriesHandler;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResponse>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    public LoginQueryHandler(IUserService userService,IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork=unitOfWork;
    }
    public async Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var result=  await _userService.Login(request.LoginRequest);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}
