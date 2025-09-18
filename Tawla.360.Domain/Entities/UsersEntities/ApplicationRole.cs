using System;
using Microsoft.AspNetCore.Identity;

namespace Tawla._360.Domain.Entities.UsersEntities;

public class ApplicationRole : IdentityRole<Guid>
{
    public string[] Permissions { get; set; }
}
