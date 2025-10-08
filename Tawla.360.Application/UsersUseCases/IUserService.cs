using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Application.UsersUseCases;

public interface IUserService : IHasIdGenericService<ApplicationUser, CreateUserDto, UpdateUserDto, UserListDto, UserDto, LiteUserDto>
{
    Task CreateRestaurantAdmin(CreateRestaurantAdminDto createRestaurant, Guid restaurantId);
    Task<AuthResponse> Login(LoginRequest login);
    Task ResetPassword(string email, string token, string newPassword);
}
