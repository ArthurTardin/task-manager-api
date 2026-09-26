using Microsoft.AspNetCore.Identity;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}