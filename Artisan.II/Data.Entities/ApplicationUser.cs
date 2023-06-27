using Artisan.II.Data.Entities.UserFiles;
using Microsoft.AspNetCore.Identity;

namespace Artisan.II.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public UserFile? Avatar { get; set; }
    public string? AvatarName { get; set; }
}