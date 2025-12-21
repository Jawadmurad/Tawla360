using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;
using Tawla._360.Application.Services;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Domain.Entities.UsersEntities;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Hosting;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.AuthUseCases;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Exceptions;
using Tawla._360.Application.Constants;
using System.Linq.Expressions;
using LinqKit;
using Tawla._360.Shared;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.Common.Extensions;

namespace Tawla._360.Application.UsersUseCases;

public class UserService : HasIdGenericService<ApplicationUser, CreateUserDto, UpdateUserDto, UserListDto, UserDto, LiteUserDto>, IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly IWebHostEnvironment _env;
    private readonly IJwtService _jwtService;
    public UserService(IHasIdRepository<ApplicationUser> repository, IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmailSender emailSender, IWebHostEnvironment env, IJwtService jwtService, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _emailSender = emailSender;
        _env = env;
        _jwtService = jwtService;
    }
    public override async Task<IReadOnlyList<UserListDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsNoTrackingAsync(c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
        return _mapper.Map<IReadOnlyList<UserListDto>>(entities);
    }
    public override Task<IReadOnlyList<LiteUserDto>> GetLiteAsync(Expression<Func<ApplicationUser, bool>> filter = null)
    {
        var predicate = PredicateBuilder.New<ApplicationUser>(c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
        if (filter != null)
            predicate = predicate.And(filter);
        var projection = GenerateProjectionExpression<ApplicationUser, LiteUserDto>(_httpContextAccessorService.GetAcceptedLanguage());
        return _repository.Select(projection, predicate);
    }
    public override async Task<PagingResult<UserListDto>> GetPagedAsync(QueryRequestDto query)
    {
        var predicate = PredicateBuilder.New<ApplicationUser>(c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
        var filter = query.FilterGroup.BuildFilter<ApplicationUser>();
        if (filter != null)
            predicate = predicate.And(filter);
        var orderBy = query.Sort.BuildSorting<ApplicationUser>();
        var pagedResult = await _repository.GetPagedAsync(query.Paging.PageNumber, query.Paging.PageSize, predicate, orderBy);
        var mappedItems = _mapper.Map<List<UserListDto>>(pagedResult.Data);
        return new PagingResult<UserListDto>()
        {
            Data = mappedItems,
            Count = pagedResult.Count
        };
    }
    public override async Task<UserDto> CreateAsync(CreateUserDto createDto)
    {
        var resId = _httpContextAccessorService.GetRestaurantId();

        var user = _mapper.Map<ApplicationUser>(createDto);
        user.RestaurantId = resId;
        var result = await _userManager.CreateAsync(user);
        if (result.Errors.Any())
        {
            //TODO:throw error 
        }
        await _userManager.AddPasswordAsync(user, createDto.Password);
        await _userManager.AddToRoleAsync(user, createDto.RoleName);
        return _mapper.Map<UserDto>(user);
    }
    public async Task ResetPassword(string email, string token, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new Exception("User not found");

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BadRequestException($"Password reset failed: {errors}");
        }

        user.EmailConfirmed = true;
        await _userManager.UpdateAsync(user);
    }


    public async Task CreateRestaurantAdmin(CreateRestaurantAdminDto createRestaurant, Guid restaurantId)
    {
        var user = new ApplicationUser
        {
            UserName = createRestaurant.Email,
            Email = createRestaurant.Email,
            UserType = UserType.RestaurantAdmin,
            RestaurantId = restaurantId,
            FirstName = createRestaurant.FirstName,
            LastName = createRestaurant.LastName,
        };
        await _userManager.CreateAsync(user);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        System.Console.WriteLine(token);
        var resetPasswordUrlBase = _configuration["EmailSettings:ResetPasswordUrl"];
        var resetLink = $"{resetPasswordUrlBase}?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";
        var templatePath = Path.Combine(_env.WebRootPath, "Emails", "ResetPassword.html");
        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Email template not found at {templatePath}");

        var htmlBody = await File.ReadAllTextAsync(templatePath);
        htmlBody = htmlBody
            .Replace("{{UserName}}", user.UserName)
            .Replace("{{ResetLink}}", resetLink);
        await _emailSender.SendEmailAsync(user.Email, "Set your password", htmlBody);

    }

    public async Task<AuthResponse> Login(LoginRequest login)
    {
        var user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null)
        {
            throw new BadRequestException(ErrorMessages.UsersErrorMessage.IncorrectEmailOrPassword);
        }
        var validPassword = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!validPassword)
        {
            throw new BadRequestException(ErrorMessages.UsersErrorMessage.IncorrectEmailOrPassword);
        }
        return await _jwtService.GenerateTokensAsync(user);

    }

    public async Task AssignUserToBranch(Guid userId, Guid branchId)
    {
        var user = await _repository.GetByIdAsync(userId, c => c.UserBranches);
        user.UserBranches.Add(new UserBranch()
        {
            BranchId = branchId
        });
        _repository.Update(user);
    }

    public async Task UnAssignUserToBranch(Guid userId, Guid branchId)
    {
        var user = await _repository.GetByIdAsync(userId, c => c.UserBranches);
        user.UserBranches.Remove(user.UserBranches.First(c => c.BranchId == branchId));
        _repository.Update(user);

    }
}
