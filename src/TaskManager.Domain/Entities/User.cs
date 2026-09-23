using TaskManager.Domain.Enums;
namespace TaskManager.Domain.Entities;

public class User
{
    private string _email = "";
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email
    {
        get { return _email;}
        set { _email = value.ToLowerInvariant();}
    }
    public DateTime CreatedAt { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;
}