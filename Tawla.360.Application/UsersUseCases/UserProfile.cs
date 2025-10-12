using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Application.UsersUseCases;

public class UserProfile:MappingProfile<ApplicationUser,CreateUserDto,UpdateUserDto,UserListDto,UserDto,LiteUserDto>
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, ApplicationUser>()
        .ForMember(dest => dest.UserBranches, opt => opt.MapFrom(src=>src.BranchesIds.Select(c=>new UserBranch()
        {
            BranchId = c,
        })))
        .ForMember(c=>c.UserName,opt=>opt.MapFrom(src=>src.Email));
    }
}
