using TaskManager.Domain.Enums;
namespace TaskManager.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;
}