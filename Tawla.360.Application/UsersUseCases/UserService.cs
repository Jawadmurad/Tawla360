using System;
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

namespace Tawla._360.Application.UsersUseCases;

public class UserService : HasIdGenericService<ApplicationUser, CreateUserDto, UpdateUserDto, UserListDto, UserDto, LiteUserDto>, IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly IWebHostEnvironment _env;
    public UserService(IHasIdRepository<ApplicationUser> repository, IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmailSender emailSender, IWebHostEnvironment env) : base(repository, mapper)
    {
        _userManager = userManager;
        _configuration = configuration;
        _emailSender = emailSender;
        _env = env;
    }

    public async Task CreateRestaurantAdmin(CreateRestaurantAdminDto createRestaurant, Guid restaurantId)
    {
        var user = new ApplicationUser
        {
            UserName = createRestaurant.Email,
            Email = createRestaurant.Email,
            UserType = UserType.RestaurantAdmin,
            RestaurantId = restaurantId
        };
        await _userManager.CreateAsync(user);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);       
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
}
